using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<int> GetAllMoviesByUserId(int uId);
    }
}
