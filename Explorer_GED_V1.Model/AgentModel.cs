using System;

namespace Explorer_GED_V1.Model
{
    public class AgentModel
    {
        public Guid AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentSurname { get; set; }
        public string AgentPostName { get; set; }
        public string AgentEmail { get; set; } 
        public string AgentPassword { get; set; } 
        public string AgentCellphone { get; set; }
        public string AgentAddress { get; set; }
        public DateTime AgentCreatedDate { get; set; }
        public bool IsAgentActive { get; set; } 
        public string AgentPhoto { get; set; }
        public Guid UserTypeId { get; set; }
        public UserTypeModel UserType { get; set; }
    }
}
