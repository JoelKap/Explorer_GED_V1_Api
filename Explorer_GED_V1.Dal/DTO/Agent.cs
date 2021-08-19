using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Agent
    {
        public Agent()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentSurname { get; set; }
        public string AgentPostName { get; set; }
        public string AgentEmail { get; set; }
        public string AgentPassword { get; set; }
        public string AgentCellphone { get; set; }
        public string AgentAddress { get; set; }
        public DateTime? AgentCreatedDate { get; set; }
        public bool? IsAgentActive { get; set; }
        public string AgentPhoto { get; set; }
        public Guid? UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
