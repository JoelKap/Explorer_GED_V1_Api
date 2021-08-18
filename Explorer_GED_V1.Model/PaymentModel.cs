using System;
using System.Drawing;

namespace Explorer_GED_V1.Model
{
    public class PaymentModel
    {
        public Guid PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; } 
        public string CellulairePayment { get; set; }
        public string CardExpiryDate { get; set; } 
        public string Photo { get; set; } 
        public string CVV { get; set; }
        public int PaymentAmount { get; set; } 
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentApprovalDate { get; set; } 
        public DateTime PaymentPrintingDate { get; set; }
        public string PaymentStatus { get; set; }   
        public string PaymentReference { get; set; } 
        public Guid UserId { get; set; }
        public Guid AgentId { get; set; }
        public Guid DocumentId { get; set; } 
        public Guid FatherId { get; set; }
        public Guid MotherId { get; set; } 
        public string CollectionPlace { get; set; }
        public DocumentModel Document { get; set; }
        public FatherModel Father { get; set; }
        public MotherModel Mother { get; set; }
        public UserModel User { get; set; } 
        public string PaymentComment { get; set; }
    }
}
