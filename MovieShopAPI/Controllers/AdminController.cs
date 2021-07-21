using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public AdminController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("movie")]
        public async Task<IActionResult> ConfirmPurchase([FromBody] PurchaseModel model)
        { 
            var purchase =  await _purchaseService.Purchase(model);
            return CreatedAtRoute("GetPurchase", model.UserId, purchase);
        }

        [HttpGet("purchase",Name = "GetPurchase")]
        public async Task<IActionResult> GetPurchaseByUserId(int userId)
        {
            var purchase = await _purchaseService.GetPurchaseByUserId(userId);
            if (purchase == null) return NotFound("This user have never bought any movie");
            return Ok(purchase);
        }

        [HttpPut("movie")]
        public async Task<IActionResult> UpdatePurchase(PurchaseModel model)
        {
            var purchase = await _purchaseService.Purchase(model);
            return CreatedAtRoute("GetPurchase", model.UserId, purchase);
        }
    }
}
