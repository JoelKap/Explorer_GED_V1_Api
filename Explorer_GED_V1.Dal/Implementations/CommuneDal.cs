using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Explorer_GED_V1.Dal.Implementations
{
    public class CommuneDal : ICommuneDal
    {
        private readonly ExplorerContext _explorerContext;
        public CommuneDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }

        public List<CommuneModel> GetCommunes()
        {
            var communes = _explorerContext.Communes.ToList();
            var list = new List<CommuneModel>();
            for (int i = 0; i < communes.Count; i++)
            {
                list.Add(new CommuneModel()
                {
                    CommuneDescription = communes[i].CommuneDescription,
                    CommuneId = communes[i].CommuneId,
                    CommuneName = communes[i].CommuneName
                });
            }
            return list;
        }

        public bool CreateCommune(CommuneModel request)
        {
            var communeDto = new Commune()
            {
                CommuneDescription = request.CommuneDescription,
                CommuneName = request.CommuneName,
                CommuneId = Guid.NewGuid()
            };
            _explorerContext.Communes.Add(communeDto);
            _explorerContext.SaveChanges();
            return true;
        }

        public bool UpdateCommune(CommuneModel request)
        {
            var communeDto = _explorerContext.Communes.Where(x => x.CommuneId == request.CommuneId).FirstOrDefault();
            communeDto.CommuneDescription = request.CommuneDescription;
            communeDto.CommuneId = request.CommuneId;
            communeDto.CommuneName = request.CommuneName;
            _explorerContext.SaveChanges();
            return true;
        }
    }
}
