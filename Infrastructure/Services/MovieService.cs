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


        public List<MovieCardResponsemodel> GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}
