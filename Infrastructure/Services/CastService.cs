using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastByIdAsync(int cid)
        {
            var cast = await _castRepository.GetCastByIdAsync(cid);
            var castDto = new CastDetailsResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender == "2" ? "male" : "female",
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            };

            castDto.Movies = new List<MovieCardResponseModel>();
            foreach (var movie in cast.MovieCasts)
            {
                castDto.Movies.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Budget = movie.Movie.Budget.GetValueOrDefault(),
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });
            }

            return castDto;
        }
    }
}
