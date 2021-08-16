using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Province
    {
        public Guid ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceDescription { get; set; }
    }
}
