using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.App.Dtos;
using TMS.core.Entites;

namespace TMS.App.Interface.Services
{
  public  interface IUserService
    {
        Task<AuthResponse> Register(RegisterDto registerDto);
        Task<AuthResponse> Login(LoginDto loginDto);
    }

}
