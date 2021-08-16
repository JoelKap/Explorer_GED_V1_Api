using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Payment
    {
        public Guid PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string Photo { get; set; }
        public string Cvv { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? PaymentApprovalDate { get; set; }
        public DateTime? PaymentPrintingDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentComment { get; set; }
        public Guid DocumentId { get; set; }
        public Guid FatherId { get; set; }
        public Guid MotherId { get; set; }
        public Guid AgentId { get; set; }
        public string CollectionPlace { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Document Document { get; set; }
        public virtual Father Father { get; set; }
        public virtual Mother Mother { get; set; }
    }
}
