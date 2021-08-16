using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Father
    {
        public Father()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid FatherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public DateTime Dob { get; set; }
        public string Town { get; set; }
        public string Province { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
