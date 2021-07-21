using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDetailsModel>> GetReviewDetailsByMovieId(int movieId);
        Task<IEnumerable<ReviewDetailsModel>> GetReviewDetailsByUserId(int userId);
    }
}
