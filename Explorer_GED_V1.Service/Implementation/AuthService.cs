using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Explorer_GED_V1.Service.Implementation
{
    public class AuthService: IAuthService
    {
        private readonly IAuthDal _authDal;
        private IConfiguration _config;
        public AuthService(IAuthDal authDal, IConfiguration config)
        {
            _authDal = authDal;
            _config = config;
        }

        public AgentModel GetUser(string email, string password)
        {
            return _authDal.GetUser(email, password);
        }

        public LoginResponseModel Token(AgentModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtConfig:secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, user.AgentEmail.ToString()),
                     new Claim(ClaimTypes.Name, user.AgentId.ToString()),
                     new Claim(ClaimTypes.Name, user.AgentCellphone.ToString()),
                     new Claim(ClaimTypes.Name, user.AgentCellphone.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Explorer",
                Audience = "Explorer GED"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseModel response = new LoginResponseModel()
            { 
                Token = tokenHandler.WriteToken(token),
                AgentId = user.AgentId,
                UserType = user.UserType.UserType,
                UserTypeId = user.UserType.UserTypeId
            };

            return response;
        }
    }
}
