using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPurchaseRepository : IAsyncRepository<Purchase>
    {
        void AddPurchase(Purchase purchase);
        Task<IEnumerable<Purchase>> GetPurchaseByUserId(int uId);
    }
}
