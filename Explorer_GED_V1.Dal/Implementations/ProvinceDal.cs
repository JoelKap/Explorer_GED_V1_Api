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
   public class ProvinceDal: IProvinceDal
    {
        private readonly ExplorerContext _explorerContext;
        public ProvinceDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }

        public List<ProvinceModel> GetProvinces()
        {
            var provinces = _explorerContext.Provinces.ToList();
            var list = new List<ProvinceModel>();
            for (int i = 0; i < provinces.Count; i++)
            {
                list.Add(new ProvinceModel()
                {
                    ProvinceDescription = provinces[i].ProvinceDescription,
                    ProvinceId = provinces[i].ProvinceId,
                    ProvinceName = provinces[i].ProvinceName
                });
            }
            return list;
        }

        public bool CreateProvince(ProvinceModel request)
        {
            var provinceDto = new Province()
            {
                ProvinceDescription = request.ProvinceDescription,
                ProvinceName = request.ProvinceName,
                ProvinceId = Guid.NewGuid()
            };
            _explorerContext.Provinces.Add(provinceDto);
            _explorerContext.SaveChanges();
            return true;
        }

        public bool UpdateProvince(ProvinceModel request)
        {
            var provinceDto = _explorerContext.Provinces.Where(x => x.ProvinceId == request.ProvinceId).FirstOrDefault();
            provinceDto.ProvinceDescription = request.ProvinceDescription;
            provinceDto.ProvinceId = request.ProvinceId;
            provinceDto.ProvinceName = request.ProvinceName;
            _explorerContext.SaveChanges();
            return true;
        }
    }
}
