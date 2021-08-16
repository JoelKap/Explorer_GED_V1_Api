using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Document
    {
        public Document()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid DocumentId { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentName { get; set; }
        public int DocumentPrice { get; set; }
        public string DocumentType { get; set; }
        public string DocumentPhoto { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
