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
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContextEF dbContext) : base(dbContext)
        {
        }

        public async void AddPurchase(Purchase purchase)
        {
           await AddAsync(purchase);
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseByUserId(int uId)
        {
            return await _dbContext.Purchases.Where(p => p.UserId == uId).ToListAsync();
        }
    }
}
