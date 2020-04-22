using System;
using System.Configuration;
using System.Linq;   //Language Integrated Natural Query
using System.Windows.Forms;

using MovieLibrary.Business;
using MovieLibrary.Business.FileSystem;
using MovieLibrary.Business.Memory;
using MovieLibrary.Business.SqlServer;
using MovieLibrary.Winforms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();            

            #region Playing with objects

            //Full name
            //MovieLibrary.Business.Movie;
            //var movie = new Movie();

            //movie.title = "Jaws";
            //movie.description = movie.title;

            //movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);
            //DisplayConfirmation("Are you sure?", "Start");
            #endregion
        }
        #endregion
        
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);
            
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _movies = new SqlMovieDatabase(connString.ConnectionString);

            ////Call extension method as though it is an instance - discover it
            ////SeedDatabase.SeedIfEmpty(_movies);  //Compiles to this
            //try
            //{
            //    _movies.SeedIfEmpty();
            //} catch (InvalidOperationException)
            //{
            //    DisplayError("Invalid op");
            //} catch (ArgumentException)
            //{
            //    DisplayError("Invalid argument");
            //} catch (Exception ex)
            //{
            //    DisplayError(ex.Message);
            //};

            UpdateUI();
        }

        // Deferred execution:
        // IEnumerable<T> returning LINQ methods are deferred execution
        // All other methods execute immediately - To?, First?, Last?, Single?
        
        private Movie GetSelectedMovie ()
        {
            //Preferred
            //return lstMovies.SelectedItem as Movie;            
            
            //SelectedObjectCollection : IEnumerable
            // IEnumerable<T> Cast<T> ( this IEnumerable source )
            // IEnumerable<T> OfType<T> ( this IEnumerable source )
            var selectedItems = lstMovies.SelectedItems.OfType<Movie>();

            // T? FirstOrDefault ( this IEnumerable<T> ) :: Returns first item that meets criteria or default for type if none
            // T? LastOrDefault ( this IEnumerable<T> ) :: Returns last item that meets criteria or default for type if none; not always supported

            // T First ( this IEnumerable<T> ) :: Returns first item that meets criteria or blows up
            // T Last ( this IEnumerable<T> )  :: Returns first item that meets criteria or blows up

            // T? SingleOrDefault ( this IEnumerable<T> ) :: Returns the only item that meets criteria or default for type if none, blows up if more than one meets criteria
            // T Single ( this IEnumerable<T> ) :: Returns the only item that meets criteria or blows up
            return selectedItems.FirstOrDefault();
        }

        //private string SortByTitle ( Movie movie ) => movie.Title;
        //private int SortByReleaseYear ( Movie movie ) => movie.ReleaseYear;

        private void UpdateUI ()
        {
            lstMovies.Items.Clear();

            //Extension method approach
            //var movies = _movies.GetAll()
            //                    .OrderBy(movie => movie.Title)  // IEnumerable<T> OrderBy<T> ( this IEnumerable<T> source, Func<T, string> sorter );
            //                    .ThenByDescending(movie => movie.ReleaseYear)
            //                    ;

            //Error handling = try-catch block
            // try
            // { S* }
            // catch (T id)
            // { S* }
            // catch (T id)
            // { S* }
            //
            var movies = Enumerable.Empty<Movie>();
            try
            {
                movies = _movies.GetAll();
                //other things
            } catch (Exception e)
            {                
                DisplayError($"Failed to load movies: {e.Message}");
            };

            //LINQ syntax 
            //  from movie in IEnumerable<T>
            //  [where expression]
            //  [orderby property1 [, other properties]
            //  select movie
            movies = from movie in movies
                     where movie.Id > 0
                     orderby movie.Title, movie.ReleaseYear descending
                     select movie;

            // T[] ToArray ( this IEnumerable<T> source ) = returns source as an array            
            // List<T> ToList ( this IEnumerable<T> source ) = returns source as a List<T>
            //var temp = new List<Movie>();
            //foreach (var item in movies)
            //    temp.Add(item);
            //return temp;                                    
            lstMovies.Items.AddRange(movies.ToArray()); //Enumerable.ToArray(movies)
            //foreach (var movie in movies)
            //{
            //    lstMovies.Items.Add(movie);
            //};
        }
                                  
        #region Event Handlers

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    var movie = _movies.Add(child.Movie);
                    
                    UpdateUI();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                };                
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.Movie = movie;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save the movie
                try
                {
                    _movies.Update(movie.Id, child.Movie);
                    UpdateUI();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                };
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {movie.Title}?", "Delete"))
                return;

            try
            {
                _movies.Delete(movie.Id);
                UpdateUI();
            } catch (Exception ex)
            {
                DisplayError(ex.Message);
            };
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }
        #endregion

        #region Private Members

        private IMovieDatabase _movies;

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message">Error to display.</param>
        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
