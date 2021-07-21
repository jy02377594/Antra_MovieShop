using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<int> GetAllMoviesByUserId(int uId)
        {
            var movies = await _purchaseRepository.GetPurchaseByUserId(uId);
            return movies.Count();
        }

        public async Task<IEnumerable<PurchaseModel>> GetPurchaseByUserId(int uid)
        {
            var movies = await _purchaseRepository.GetPurchaseByUserId(uid);
            var model = new List<PurchaseModel>();
            foreach (var movie in movies)
            {
                model.Add(new PurchaseModel { 
                    MovieId = movie.MovieId,
                    PurchaseDateTime = movie.PurchaseDateTime,
                    PurchaseNumber = movie.PurchaseNumber,
                    TotalPrice = movie.TotalPrice,
                    UserId = movie.UserId
                });
            }
            return model;
        }

        public async Task<PurchaseModel> Purchase(PurchaseModel model)
        {
            var entity = new Purchase
            {
                PurchaseDateTime = model.PurchaseDateTime,
                MovieId = model.MovieId,
                PurchaseNumber = model.PurchaseNumber,
                TotalPrice = model.TotalPrice,
                UserId = model.UserId
            };
            await _purchaseRepository.AddPurchase(entity);
            return model;
        }

        public async Task<PurchaseModel> UpdatePurchase(int pId, PurchaseModel model)
        {
            var entity = new Purchase
            {
                PurchaseDateTime = model.PurchaseDateTime,
                MovieId = model.MovieId,
                PurchaseNumber = model.PurchaseNumber,
                TotalPrice = model.TotalPrice,
                UserId = model.UserId
            };
            await _purchaseRepository.UpdatePurchase(entity);
            return model;
        }
    }
}
