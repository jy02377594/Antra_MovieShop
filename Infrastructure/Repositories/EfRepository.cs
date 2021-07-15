using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContextEF _dbContext;
        public EfRepository(MovieShopDbContextEF dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            //var movie = await _dbContext.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
            //return movie;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
