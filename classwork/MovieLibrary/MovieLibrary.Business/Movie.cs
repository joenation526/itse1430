using System;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie
    {
        public Genre Genre { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //Never return null from a string property, always return empty string
            get {
                //Long, long way
                //if (_title == null)
                //    return "";

                //return _title;

                //Long way
                //return (_title != null) ? _title : "";

                //Correct - use null coalesce operator
                return _title ?? "";
            }

            //Use null conditional operator if instance value can be null
            set { _title = value?.Trim(); }
        }
        private string _title;

        /// <summary>Gets or sets the run length in minutes.</summary>
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;
        public int RunLength { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        //Can use auto property with default value for underlying field
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Determines if this is a classic movie.</summary>
        //public bool IsClassic
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic;
        public bool IsClassic { get; set; }

        //Calculated property, no setter
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1930; }
        }

        //public int Id
        //{
        //    get { return _id; }
        //    private set { _id = value; }
        //}
        //private int _id;
        //Public getter, private setter using auto property syntax
        public int Id { get; }

        public override string ToString ()
        {
            return Title;
        }

        public bool Validate ( out string error )
        {
            //Title is required
            //if (txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                error = "Title is required.";
                return false;
            };

            //Run length >= 0
            if (RunLength < 0)
            {
                error = "Run length must be >= 0.";
                return false;
            };

            //Release year >= 1900
            if (ReleaseYear < 1900)
            {
                error = "Release year must be >= 1900.";
                return false;
            };

            error = null;
            return true;
        }
    }
}
