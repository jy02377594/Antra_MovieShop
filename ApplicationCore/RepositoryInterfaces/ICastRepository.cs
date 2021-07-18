using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICastRepository:IAsyncRepository<Cast>
    {
        Task<List<Cast>> GetAllCasts();
        Task<Cast> GetCastByIdAsync(int cid);
    }
}
