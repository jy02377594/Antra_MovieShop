using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IPurchaseRepository _purchaseRepository;
        public UserController(ICurrentUser currentUser, IPurchaseRepository purchaseRepository)
        {
            _currentUser = currentUser;
            _purchaseRepository = purchaseRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmPurchase(int mId, decimal price)
        {
            if (_currentUser.IsAuthenticated == false)
            {
                //return View("~/Views/Account/Login.cshtml");
                return LocalRedirect("~/Account/Login");
            }
            var entity = new Purchase
            {
                MovieId = mId,
                UserId = _currentUser.UserId,
                PurchaseDateTime = DateTime.Now,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = price
            };

            await _purchaseRepository.AddAsync(entity);
            return LocalRedirect("~/");
        }
    }
}
