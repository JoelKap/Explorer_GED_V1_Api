using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explorer_GED_V1_Api.Controllers
{

    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet("api/[controller]/GetProvinces")]
        public ActionResult GetProvinces()
        {
            return Ok(_provinceService.GetProvinces());
        }

        [HttpPost("api/[controller]/CreateProvince")]
        public IActionResult CreateProvince([FromBody] ProvinceModel request)
        {
            return Ok(_provinceService.CreateProvince(request));
        }


        [HttpPut("api/[controller]/UpdateProvince")]
        public IActionResult UpdateProvince([FromBody] ProvinceModel request)
        {
            return Ok(_provinceService.UpdateProvince(request));
        }
    }
}
