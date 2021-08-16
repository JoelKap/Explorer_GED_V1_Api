using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Dal.Contracts
{
    public interface IDocumentDal
    {
        List<DocumentModel> GetDocuments();
        bool CreateDocument(DocumentModel request);
        bool UpdateDocument(DocumentModel request);
    }
}
 