using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.DTOs
{
    public class UserDTO
    {
        public int Userid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public DateOnly? Dateofbirth { get; set; }
        //public byte[]? Photo { get; set; }
        public string? Nationality { get; set; }
        public string? Profession { get; set; }
        public int? Phonenumber { get; set; }
        public int? Roleid { get; set; }
        public DateOnly? Datejoining { get; set; }
        public int? EmergencyNumber { get; set; }
    }

}
