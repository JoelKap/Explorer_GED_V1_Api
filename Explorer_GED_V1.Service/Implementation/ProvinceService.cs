using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Implementation
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceDal _provinceDal;
        public ProvinceService(IProvinceDal provinceDal)
        {
            _provinceDal = provinceDal;
        }

        public List<ProvinceModel> GetProvinces()
        {
            return _provinceDal.GetProvinces();
        }

        public bool CreateProvince(ProvinceModel request)
        {
            request.ProvinceId = System.Guid.NewGuid();
            return _provinceDal.CreateProvince(request);
        }

        public bool UpdateProvince(ProvinceModel request)
        {
            return _provinceDal.UpdateProvince(request);
        }
    }
}
