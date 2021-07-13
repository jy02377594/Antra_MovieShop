using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        MovieShopDbContext db;
        public MovieService()
        {
            db = new MovieShopDbContext();
        }

        public IEnumerable<MovieDto> GetAllMovies()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<MovieDto>("Select top 50 * from Movie");
        }

        public MovieDto GetMovieById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<MovieDto>("Select Id,Title,Overview, Tagline, Budget, Revenue, PosterUrl," +
                "BackdropUrl,ReleaseDate,Price from Movie where Id = @MovieId", new { MovieId = id });
        }


        public List<MovieCardResponseModel> GetTopRevenueMovies()
        {
            var movies = new List<MovieCardResponseModel> {

                          new MovieCardResponseModel {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                          new MovieCardResponseModel {Id = 2, Title = "Avatar", Budget = 1200000},
                          new MovieCardResponseModel {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
                          new MovieCardResponseModel {Id = 4, Title = "Titanic", Budget = 1200000},
                          new MovieCardResponseModel {Id = 5, Title = "Inception", Budget = 1200000},
                          new MovieCardResponseModel {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
                          new MovieCardResponseModel {Id = 7, Title = "Interstellar", Budget = 1200000},
                          new MovieCardResponseModel {Id = 8, Title = "Fight Club", Budget = 1200000},
            };

            return movies;
        }

        public Task<MovieDto> GetMovieByIdAsync(int id)
        {
            IDbConnection conn = db.GetConnection();
            var res = conn.QueryFirstOrDefaultAsync<MovieDto>("Select Id,Title,Overview, Tagline, Budget, Revenue, PosterUrl," +
                "BackdropUrl,ReleaseDate,Price from Movie where Id = @MovieId", new { MovieId = id });
            return res;
        }

        public Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryAsync<MovieDto>("Select top 1000 * from Movie");
        }
    }
}
