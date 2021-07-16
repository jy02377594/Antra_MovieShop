using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        MovieDto GetMovieById(int id);
        Task<MovieDto> GetMovieByIdAsync(int id);
        IEnumerable<MovieDto> GetAllMovies();
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();

        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
    }
}
