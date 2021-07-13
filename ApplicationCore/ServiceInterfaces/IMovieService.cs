using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        List<MovieCardResponseModel> GetTopRevenueMovies();
        MovieDto GetMovieById(int id);
        Task<MovieDto> GetMovieByIdAsync(int id);
        IEnumerable<MovieDto> GetAllMovies();
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    }
}
