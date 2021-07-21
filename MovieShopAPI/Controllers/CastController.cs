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
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCastByCid(int cid)
        {
           var model = await _castService.GetCastByIdAsync(cid);
            if (model == null) return NotFound("There is no cast");
            return Ok(model);
        }
    }
}
