using System;
using System.Collections.Generic;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class Commune
    {
        public Guid CommuneId { get; set; }
        public string CommuneName { get; set; }
        public string CommuneDescription { get; set; }
    }
}
