using ApplicationCore.Models;
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
        Task<PurchaseModel> Purchase(PurchaseModel model);
        Task<IEnumerable< PurchaseModel>> GetPurchaseByUserId(int uid);
        Task<PurchaseModel> UpdatePurchase(int pId, PurchaseModel model);
    }
}
