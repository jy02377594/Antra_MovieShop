using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContextEF dbContext) : base(dbContext)
        {
        }


        public void AddReviewWithUserId(int userId, Review review)
        {
            review.UserId = userId;
            _dbContext.Reviews.Add(review);
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == movieId).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserId(int userId)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.UserId == userId).ToListAsync();
            return reviews;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateReviewWithUserId(int userId, Review review)
        {
            review.UserId = userId;
        }
    }
}
