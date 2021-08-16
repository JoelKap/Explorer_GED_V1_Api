using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Explorer_GED_V1_Api.Controllers
{

    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }


        [HttpGet("api/[controller]/GetDocuments")]
        public ActionResult GetDocuments()
        {
            return Ok(_documentService.GetDocuments());
        }
         
        [HttpPost("api/[controller]/CreateDocument")]
        public IActionResult CreateDocument([FromBody] DocumentModel request)
        {
            return Ok(_documentService.CreateDocument(request));
        }


        [HttpPut("api/[controller]/UpdateDocument")]
        public IActionResult UpdateDocument([FromBody] DocumentModel request)
        {
            return Ok(_documentService.UpdateDocument(request));
        }
    }
}
