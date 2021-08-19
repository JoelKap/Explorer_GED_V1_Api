using System;

namespace Explorer_GED_V1.Model
{
    public class UserModel
    {
        public Guid UserId { get; set; } 
        public string Name { get; set; }
        public string PostName { get; set; } 
        public string Surname { get; set; }
        public string streetName { get; set; }
        public string StreetNumber { get; set; }
        public string Quartier { get; set; }  
        public string Commune { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public DateTime Dob { get; set; }

    }
}
