using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieLibrary.Business;
using MovieLibrary.Business.SqlServer;
using MovieLibrary.WebApp.Models;

namespace MovieLibrary.WebApp.Controllers
{
    public class MovieController : Controller
    {
        public MovieController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _database = new SqlMovieDatabase(connString.ConnectionString);
        }

        // GET: Movie 
        [HttpGet]
        public ActionResult Index()
        {
            var movies = _database.GetAll();

            var model = movies.Select(m => ToModel(m))
                              .OrderBy(m => m.Title)
                              .ThenBy(m => m.ReleaseYear);

            return View("List", model);
        }

        [HttpGet]
        public ActionResult Create ( )
        {
            var model = new MovieModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create ( MovieModel model )
        {
            //Is model valid?
            if (ModelState.IsValid)
            {
                var movie = new Movie();
                movie.Title = model.Title;
                movie.Description = model.Description;
                if (!String.IsNullOrEmpty(model.Genre))
                    movie.Genre = new Genre(model.Genre);
                else
                    movie.Genre = null;
                movie.ReleaseYear = model.ReleaseYear;
                movie.RunLength = model.RunLength;
                movie.IsClassic = model.IsClassic;

                try
                {
                    _database.Add(movie);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete ( int id )
        {
            var movie = _database.Get(id);

            var model = ToModel(movie);
            return View(model);
        }

        [HttpPost]
        //[HttpDelete]
        public ActionResult Delete ( MovieModel model )
        {            
            try
            {
                _database.Delete(model.Id);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var movie = _database.Get(id);

            var model = ToModel(movie);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit ( MovieModel model )
        {
            //Is model valid?
            if (ModelState.IsValid)
            {
                var movie = _database.Get(model.Id);
                if (movie == null)
                    return HttpNotFound();

                movie.Title = model.Title;
                movie.Description = model.Description;
                if (!String.IsNullOrEmpty(model.Genre))
                    movie.Genre = new Genre(model.Genre);
                else
                    movie.Genre = null;
                movie.ReleaseYear = model.ReleaseYear;
                movie.RunLength = model.RunLength;
                movie.IsClassic = model.IsClassic;

                try
                {
                    _database.Update(model.Id, movie);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        private MovieModel ToModel ( Movie movie )
        {
            return new MovieModel() {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                RunLength = movie.RunLength,
                ReleaseYear = movie.ReleaseYear,
                IsClassic = movie.IsClassic,
                Genre = movie.Genre?.Description
            };
        }

        private readonly IMovieDatabase _database;
    }
}