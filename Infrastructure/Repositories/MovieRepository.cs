using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContextEF dbContext) : base(dbContext)
        {

        }

        public async Task<List<Movie>> GetHighestGrossingMovies()
        {
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;
        }

        public override async Task<Movie> GetById(int id)
        {
            var movie = await _dbContext.Movies.Include(movie => movie.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception($"No Movie Found with {id}");
            }

            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0)
            {
                movie.Rating = movieRating.GetValueOrDefault();
            }
            return movie;
        }
    }
}
