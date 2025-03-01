using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.DTOs
{
    public class UserLoginDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public int Roleid { get; set; } 
    }

}
