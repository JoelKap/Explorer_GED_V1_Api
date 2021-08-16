using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer_GED_V1.Service.Implementation
{
   public class CommuneService: ICommuneService
    {
        private readonly ICommuneDal _communeDal;
        public CommuneService(ICommuneDal communeDal)
        {
            _communeDal = communeDal;
        }

        public List<CommuneModel> GetCommunes()
        {
            return _communeDal.GetCommunes();
        }

        public bool UpdateCommune(CommuneModel request)
        {
            return _communeDal.UpdateCommune(request);
        }

        public bool CreatCommune(CommuneModel request)
        {
            return _communeDal.CreateCommune(request);
        }
    }
}
