using System;

namespace Explorer_GED_V1.Model
{
    public class DocumentModel
    {
        public Guid DocumentId { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentName { get; set; }
        public int DocumentPrice { get; set; } 
        public string DocumentType { get; set; }
        public  string  DocumentPhoto { get; set; }
    }
}
