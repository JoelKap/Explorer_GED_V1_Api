﻿using System;

namespace Explorer_GED_V1.Model
{
    public class FatherModel
    {
        public Guid FatherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Firstname { get; set; }
        public DateTime Dob { get; set; }
        public string Town { get; set; }  
        public string FatherProvince { get; set; }

    }
}
