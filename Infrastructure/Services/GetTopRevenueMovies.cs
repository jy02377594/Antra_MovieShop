using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GetTopRevenueMovies : IMovieService
    {
        public List<MovieDto> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        List<MovieCardResponsemodel> IMovieService.GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}
