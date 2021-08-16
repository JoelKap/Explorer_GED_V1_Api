using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Dal.Contracts
{
    public interface ICommuneDal
    {
        List<CommuneModel> GetCommunes();
        bool CreateCommune(CommuneModel request);
        bool UpdateCommune(CommuneModel request);
    }
} 
