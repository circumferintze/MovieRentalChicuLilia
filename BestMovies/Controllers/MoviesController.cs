using BestMovies.BestMoviesDB;
using BestMovies.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BestMovies.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext _movieContext = new MovieContext();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _movieContext.Movies.ToList();

            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movieContext.Movies.FirstOrDefault(m => m.MoviesId == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var movieModel = new MovieModel()
            {
                Genres = _movieContext.Genres.Select(g => g.Name).ToList()
            };
            return View(movieModel);
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(MovieModel createMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var genre = _movieContext.Genres.FirstOrDefault(g => g.Name == createMovie.Genre);
                    var movie = new Movies()
                    {
                        Title = createMovie.Title,
                        Genre = genre,
                        ReleaseDate = createMovie.ReleaseDate,
                        Added = DateTime.Now,
                        NumberInStock = createMovie.NumberInStock
                    };

                    _movieContext.Movies.Add(movie);
                    _movieContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            var movieEdit = new MovieModel()
            {
                Title = movie.Title,
                Genre = movie.Genre.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                Genres = _movieContext.Genres.Where(g => g.Name != movie.Genre.Name).Select(g => g.Name).ToList()
            };
            return View(movieEdit);
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieModel movieEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var genre = _movieContext.Genres.FirstOrDefault(g => g.Name == movieEdit.Genre);
                    var movie = _movieContext.Movies.Find(id);
                    movie.Title = movieEdit.Title;
                    movie.Genre = genre;
                    movie.ReleaseDate = movieEdit.ReleaseDate;
                    movie.NumberInStock = movieEdit.NumberInStock;

                    _movieContext.Entry(movie).State = EntityState.Modified;
                    _movieContext.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
