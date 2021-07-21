using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IReviewRepository:IAsyncRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId);
        Task<IEnumerable<Review>> GetReviewsByUserId(int userId);
        void AddReviewWithUserId(int userId, Review review);
        void UpdateReviewWithUserId(int userId, Review review);
        Task<bool> SaveAsync();

    }
}
