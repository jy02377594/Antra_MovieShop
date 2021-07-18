using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenreIdAsync(int gid);
        Task<IEnumerable<GenreModel>> GetAllGenreModelsAsync();
    }
}
