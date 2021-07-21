using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<ReviewDetailsModel>> GetReviewDetailsByMovieId(int movieId)
        {
            var entities = await _reviewRepository.GetReviewsByMovieId(movieId);
            var model = new List<ReviewDetailsModel>();
            foreach (var entity in entities)
            {
                var user = await _userRepository.GetById(entity.UserId);
                var movie = await _movieRepository.GetById(entity.MovieId);

                model.Add(new ReviewDetailsModel
                {
                    Rating = entity.Rating,
                    ReviewText = entity.ReviewText,
                    UserName = user.FirstName + user.LastName,
                    MovieName = movie.Title
                });
            }

            return model;
        }

        public async Task<IEnumerable<ReviewDetailsModel>> GetReviewDetailsByUserId(int userId)
        {
            var entities = await _reviewRepository.GetReviewsByUserId(userId);
            var model = new List<ReviewDetailsModel>();
            foreach (var entity in entities)
            {
                var user = await _userRepository.GetById(entity.UserId);
                var movie = await _movieRepository.GetById(entity.MovieId);

                model.Add(new ReviewDetailsModel
                {
                    Rating = entity.Rating,
                    ReviewText = entity.ReviewText,
                    UserName = user.FirstName + user.LastName,
                    MovieName = movie.Title
                });
            }

            return model;
        }
    }
}
