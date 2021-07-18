using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContextEF dbContext) : base(dbContext)
        {
        }

        public Task<List<Cast>> GetAllCasts()
        {
            throw new NotImplementedException();
        }

        public async Task<Cast> GetCastByIdAsync(int cid)
        {
            return await _dbContext.Casts.Include(c => c.MovieCasts).ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == cid);
        }
    }
}
