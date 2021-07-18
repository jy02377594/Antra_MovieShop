using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var movies = await _movieService.GetMovieDetails(id);
            return View(movies);
        }

        public async Task<IActionResult> Genre(int gid)
        {
            var movies = await _genreService.GetMoviesByGenreIdAsync(gid);
            return View("~/Views/Home/Index.cshtml",movies);
        }
    }
}
