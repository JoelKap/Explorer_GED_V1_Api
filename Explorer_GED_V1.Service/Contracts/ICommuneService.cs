using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Contracts
{
    public interface ICommuneService
    {
        List<CommuneModel> GetCommunes();
        bool CreatCommune(CommuneModel request);
        bool UpdateCommune(CommuneModel request);
    }
}
