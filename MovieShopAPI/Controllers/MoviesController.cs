using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IReviewService _reviewService;

        public MoviesController(IMovieService movieService, IGenreService genreService, IReviewService reviewService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _reviewService = reviewService;
        }
        //attribute based routing
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

            return Ok(movies);
            // NewtonSoft Joson
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();

            if (movies == null) return NotFound();

            return Ok(movies);
        }

        [HttpGet("toprated")]
        public async Task<IActionResult> GetTop50RatedMovies() {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }
            return Ok(movies);
        }

        [HttpGet("genre/{genreId}")]
        public async Task<IActionResult> GetGenreByGenreId([FromRoute]int gid) {
            var movies = await _genreService.GetMoviesByGenreIdAsync(gid);
            if (movies == null)
            {
                return NotFound("No Movies in this Genre");
            }
            return Ok(movies);
        }

        [HttpGet("{id:int}/reviews")]
        public async Task<IActionResult> GetReviewsByMovieId([FromRoute] int id)
        {
            var reviews = await _reviewService.GetReviewDetailsByMovieId(id);
            if (reviews == null) return NotFound("No Review in this Movie");

            return Ok(reviews);
        }

    }
}
