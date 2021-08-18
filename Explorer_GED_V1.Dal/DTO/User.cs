using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public Guid? AgentId { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string PostName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Quartier { get; set; }
        public string Commune { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public DateTime? Dob { get; set; }

        public virtual Agent Agent { get; set; }
    }
}
