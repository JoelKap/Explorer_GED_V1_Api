using System;

namespace Explorer_GED_V1.Model
{
    public class LoginResponseModel 
    {
        public string Token { get; set; }  
        public string UserType { get; set; }
        public Guid AgentId { get; set; } 
        public Guid UserTypeId { get; set; }
    }
}
