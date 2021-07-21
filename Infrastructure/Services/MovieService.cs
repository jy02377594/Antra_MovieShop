using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using static ApplicationCore.Models.MovieDetailsResponseModel;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<MovieDto> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.ListAllAsync();
            var movieDto = new List<MovieDto>();
            foreach(var movie in movies)
            {
                movieDto.Add(new MovieDto { 
                    Id = movie.Id, BackdropUrl = movie.BackdropUrl, 
                    Budget = movie.Budget.GetValueOrDefault(),
                    Overview = movie.Overview, 
                    PosterUrl = movie.PosterUrl, Price = movie.Price.GetValueOrDefault(), 
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(), 
                    Revenue = movie.Revenue.GetValueOrDefault(),
                    Tagline = movie.Tagline, 
                    Title = movie.Tagline
                });
            }
            return movieDto;
        }

        public MovieDto GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetById(id);

            var movieDetails = new MovieDetailsResponseModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Budget = movie.Budget.GetValueOrDefault(),
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Revenue = movie.Revenue, 
                PosterUrl = movie.PosterUrl,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                BackdropUrl = movie.BackdropUrl,
                Price = movie.Price,
                Rating = movie.Rating
            };

            movieDetails.Casts = new List<CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath
                });
            }

            movieDetails.Genres = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            return movieDetails;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetHighestRatedMovies();
            var movieCard = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCard.Add(new MovieCardResponseModel { 
                    Budget = movie.Budget.GetValueOrDefault(),
                    PosterUrl = movie.PosterUrl,
                    Id = movie.Id,
                    Title = movie.Title
                });
            }
            return movieCard;
        }

        //MovieShopDbContext db;
        //public MovieService()
        //{
        //    db = new MovieShopDbContext();
        //}

        //public IEnumerable<MovieDto> GetAllMovies()
        //{
        //    IDbConnection conn = db.GetConnection();
        //    return conn.Query<MovieDto>("Select top 50 * from Movie");
        //}

        //public MovieDto GetMovieById(int id)
        //{
        //    IDbConnection conn = db.GetConnection();
        //    return conn.QueryFirstOrDefault<MovieDto>("Select Id,Title,Overview, Tagline, Budget, Revenue, PosterUrl," +
        //        "BackdropUrl,ReleaseDate,Price from Movie where Id = @MovieId", new { MovieId = id });
        //}


        //public List<MovieCardResponseModel> GetTopRevenueMovies()
        //{
        //    var movies = new List<MovieCardResponseModel> {

        //                  new MovieCardResponseModel {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 2, Title = "Avatar", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 4, Title = "Titanic", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 5, Title = "Inception", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 7, Title = "Interstellar", Budget = 1200000},
        //                  new MovieCardResponseModel {Id = 8, Title = "Fight Club", Budget = 1200000},
        //    };

        //    return movies;
        //}

        //public Task<MovieDto> GetMovieByIdAsync(int id)
        //{
        //    IDbConnection conn = db.GetConnection();
        //    var res = conn.QueryFirstOrDefaultAsync<MovieDto>("Select Id,Title,Overview, Tagline, Budget, Revenue, PosterUrl," +
        //        "BackdropUrl,ReleaseDate,Price from Movie where Id = @MovieId", new { MovieId = id });
        //    return res;
        //}

        //public Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        //{
        //    IDbConnection conn = db.GetConnection();
        //    return conn.QueryAsync<MovieDto>("Select top 1000 * from Movie");
        //}

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighestGrossingMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, Budget = movie.Budget.GetValueOrDefault(), Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
        }
    }
}
