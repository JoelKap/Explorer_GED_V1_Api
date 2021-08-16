using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Explorer_GED_V1_Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("api/[controller]/Login")]
        public ActionResult CreateUserToken()
        {
            string authHeader = this.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.Authorization].ToString();

            if (string.IsNullOrEmpty(authHeader))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Incorrect user credentials");
            }

            if (!authHeader.StartsWith("Basic"))
            {
                return this.BadRequest();
            }

            string crentials = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
            string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(crentials));
            string email = decodedCredentials.Split(':', 3)[0];
            string password = decodedCredentials.Split(':', 3)[1];

            AgentModel user = this._authService.GetUser(email, password);
            if (user != null)
            {
                var loginResponse = _authService.Token(user);
                return Ok(new { response = loginResponse });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Incorrect user credentials");
            }
        }
    }
}
