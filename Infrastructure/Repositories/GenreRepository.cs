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
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContextEF dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            EfRepository<Genre> ER = new EfRepository<Genre>(_dbContext);
            return await ER.ListAllAsync();

            //return await _dbContext.Genres.OrderBy(g => g.Name).ToListAsync();
        }
        public async Task<Genre> GetGenreByGenreIdAsync(int gid)
        {
            return await _dbContext.Genres.Include(g => g.Movies).FirstOrDefaultAsync(g => g.Id == gid);
        }
    }
}
