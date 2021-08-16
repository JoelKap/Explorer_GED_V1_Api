using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Contracts
{
    public interface IProvinceService
    {
        List<ProvinceModel> GetProvinces();
        bool CreateProvince(ProvinceModel request);
        bool UpdateProvince(ProvinceModel request);
    }
}
