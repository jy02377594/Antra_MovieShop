using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenreModelsAsync()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            var genreModel = new List<GenreModel>();
            foreach (var genre in genres) {
                genreModel.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            return genreModel;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenreIdAsync(int gid)
        {
            var genre = await _genreRepository.GetGenreByGenreIdAsync(gid);

            var movieCard = new List<MovieCardResponseModel>();
            foreach (var movie in genre.Movies)
            {
                movieCard.Add(new MovieCardResponseModel { 
                    Id = movie.Id,
                   Budget = movie.Budget.GetValueOrDefault(),
                   PosterUrl = movie.PosterUrl,
                   Title = movie.Title
                });
            }

            return movieCard;
        }

    }
}
