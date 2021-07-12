using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    [ApiController]
    [Route(template:"api/Movies")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        [HttpGet(template: "{id}")]
        public string GetMovieById(int Id)
        {
            var movie = _movieService.GetMovieById(Id);
            if (movie == null) return null;
            var res = JsonConvert.SerializeObject(movie);
            return res;
        }

        [HttpGet(template:"GetAllMovies")]
        public string GetAllMovies() {
            var movies = _movieService.GetAllMovies();
            if (movies == null) return null;
            var res = JsonConvert.SerializeObject(movies);
            return res;
        }



        //[HttpGet(template: "{id}")]
        //public string GetMovieById(int id)
        //{
        //    var service = new MovieRepository();
        //    var service2 = new MovieService();
        //    var res1 = test(id, service);
        //    var res2 = test(id, service2);

        //    return res2;
        //}

        //public string test(int id, IMovieService movieService)
        //{
        //    var movie2 = movieService.GetMovieById(id);
        //    var res2 = JsonConvert.SerializeObject(movie2);

        //    return res2;
        //}

        //[HttpGet]
        //public string GetAllMovies(IMovieService movieService)
        //{
        //    var service = new MovieRepository();
        //    var res = service.GetAllMovies;

        //    var service2 = new MovieService();
        //    var res2 = JsonConvert.SerializeObject(service.GetAllMovies);
        //    return res2;
        //}

        //[HttpGet(template:"viewmovies")]
        //public JsonResult GetAllMovies(IMovieService movieService)
        //{
        //    var service = new MovieRepository();
        //    var res = JsonConvert.SerializeObject(service.GetMovieById(1));

        //    var service2 = new MovieService();
        //    var res2 = JsonConvert.SerializeObject(service.GetMovieById(1));
        //    return new JsonResult(res2);
        //}

        //public IActionResult Index(int Id)
        //{
        //    var movie = _movieService.GetMovieById(Id);
        //    if (movie == null) return null;
        //    var res = Newtonsoft.Json.JsonConvert.SerializeObject(movie);
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
