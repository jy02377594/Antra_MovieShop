using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public async Task<IActionResult> Index(int cid)
        {
            var cast = await _castService.GetCastByIdAsync(cid);
            return View("~/Views/Shared/_MovieCast.cshtml", cast);
        }
    }
}
