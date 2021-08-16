using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class UserType
    {
        public UserType()
        {
            Agents = new HashSet<Agent>();
        }

        public Guid UserTypeId { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
    }
}
