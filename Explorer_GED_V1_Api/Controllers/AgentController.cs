using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Explorer_GED_V1_Api.Controllers
{
    [ApiController]
    public class AgentController : ControllerBase
    {

        private IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet("api/[controller]/GetAgents")]
        public ActionResult GetAgents()
        {
            return Ok(_agentService.GetAgents());
        }

        [HttpPost("api/[controller]/CreateAgent")]
        public IActionResult CreateAgent([FromBody] AgentModel request)
        {
            return Ok(_agentService.CreateAgent(request));
        }


        [HttpPut("api/[controller]/UpdateAgent")]
        public IActionResult UpdateAgent([FromBody] AgentModel request)
            {
            return Ok(_agentService.UpdateAgent(request));
        }
    }
}
