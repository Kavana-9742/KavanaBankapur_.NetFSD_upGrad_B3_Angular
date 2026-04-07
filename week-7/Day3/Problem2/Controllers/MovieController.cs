using Microsoft.AspNetCore.Mvc;
using Movie_Catalog.Models;
using Movie_Catalog.Services;
using Movie_Catalog.Models;
using Movie_Catalog.Services;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _service.AddMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _service.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _service.DeleteMovie(movie.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }
    }
}