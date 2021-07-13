using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
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
    [Route(template: "api/Movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetMovieByIdAsync(int Id)
        {
            var movie = await _movieService.GetMovieByIdAsync(Id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpGet(template: "GetAllMovies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            var res = new List<MovieDto>();
            foreach (var movie in movies)
            {
                res.Add(movie);
            }
            if (movies == null) return BadRequest();
            return Ok(res);
        }
    }
}
