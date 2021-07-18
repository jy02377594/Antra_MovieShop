using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieShopMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //GET: Genres
        //public PartialViewResult Index()
        //{
        //    return PartialView("GenreView", _genreService.GetAllGenreModelsAsync());
        //}

        //public async Task<IActionResult> Genre(int gid)
        //{
        //    var movies = await _genreService.GetMoviesByGenreIdAsync(gid);
        //    return View(movies);
        //}
    }
}
