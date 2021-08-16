using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer_GED_V1.Dal.Implementations
{
   public class DocumentDal: IDocumentDal
    {
        private readonly ExplorerContext _explorerContext;

        public DocumentDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }

        public List<DocumentModel> GetDocuments()
        {
            var documents = _explorerContext.Documents.ToList();
            var list = new List<DocumentModel>();
            for (int i = 0; i < documents.Count; i++)
            {
                list.Add(new DocumentModel()
                {
                    DocumentName = documents[i].DocumentName,
                    DocumentId = documents[i].DocumentId,
                    DocumentDescription = documents[i].DocumentDescription,
                    DocumentType = documents[i].DocumentType,
                    DocumentPhoto = documents[i].DocumentPhoto,
                    DocumentPrice = documents[i].DocumentPrice
                });
            }
            return list;
        }

        public bool CreateDocument(DocumentModel request)
        {
            var documentDto = new Document()
            {
                DocumentDescription = request.DocumentDescription,
                DocumentName = request.DocumentName,
                DocumentPhoto = request.DocumentPhoto,
                DocumentPrice = request.DocumentPrice,
                DocumentType = request.DocumentType,
                DocumentId = Guid.NewGuid()
            };
            _explorerContext.Documents.Add(documentDto);
            _explorerContext.SaveChanges();
            return true;
        }

        public bool UpdateDocument(DocumentModel request)
        {
            var documentDto = _explorerContext.Documents.Where(x => x.DocumentId == request.DocumentId).FirstOrDefault();
            documentDto.DocumentDescription = request.DocumentDescription;
            documentDto.DocumentId = request.DocumentId;
            documentDto.DocumentName = request.DocumentName;
            documentDto.DocumentPhoto = request.DocumentPhoto;
            documentDto.DocumentPrice = request.DocumentPrice;
            documentDto.DocumentType = request.DocumentType;
            _explorerContext.SaveChanges();
            return true;
        }
    }
}
