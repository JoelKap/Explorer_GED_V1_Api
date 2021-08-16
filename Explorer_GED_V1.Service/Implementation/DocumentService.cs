using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Implementation
{
    public class DocumentService: IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        public DocumentService(IDocumentDal documentDal)
        {
            _documentDal = documentDal;
        }

        public List<DocumentModel> GetDocuments()
        {
            return _documentDal.GetDocuments();
        }

        public bool UpdateDocument(DocumentModel request)
        {
            return _documentDal.UpdateDocument(request);
        }

        public bool CreateDocument(DocumentModel request)
        {
            return _documentDal.CreateDocument(request);
        }
    }
}
