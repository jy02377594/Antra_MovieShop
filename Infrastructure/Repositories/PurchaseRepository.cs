using ApplicationCore.Entities;
using ApplicationCore.Models;
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

        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
           await AddAsync(purchase);
            return purchase;
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseByUserId(int uId)
        {
            return await _dbContext.Purchases.Where(p => p.UserId == uId).ToListAsync();
        }

        public async Task<Purchase> UpdatePurchase(Purchase purchase)
        {
            await UpdateAsync(purchase);
            return purchase;
        }
    }
}
