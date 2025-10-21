using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.App.Dtos
{
    public record AuthResponse(string token);

    public class LoginDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class RegisterDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
