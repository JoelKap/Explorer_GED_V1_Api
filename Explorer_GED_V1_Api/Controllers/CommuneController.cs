using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Explorer_GED_V1_Api.Controllers
{
    [ApiController]
    public class CommuneController : Controller
    {
        private ICommuneService _communeService;
        public CommuneController(ICommuneService communeService)
        {
            _communeService = communeService;
        }

        [HttpGet("api/[controller]/GetCommunes")]
        public ActionResult GetCommunes()
        {
            return Ok(_communeService.GetCommunes());
        }

        [HttpPost("api/[controller]/CreateCommune")] 
        public IActionResult CreateCommune([FromBody] CommuneModel request)
        {
            return Ok(_communeService.CreatCommune(request));
        }


        [HttpPut("api/[controller]/UpdateCommune")]
        public IActionResult UpdateCommune([FromBody] CommuneModel request)
        {
            return Ok(_communeService.UpdateCommune(request));
        }
    }
}
