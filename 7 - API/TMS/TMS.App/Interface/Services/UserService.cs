using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TMS.App.Dtos;
using TMS.core.Entites;

namespace TMS.App.Interface.Services
{
   public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<AuthResponse> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> Register(RegisterDto registerDto)
        {
            // validate 

            var user = new User
            {
                UserName = registerDto.UserName,
                Password = registerDto.PassWord
            };

            await _repository.CreateUser(user);

            var token = GenrateToken(user);

            return new AuthResponse(token);
        }

        private string GenrateToken(User user)
        {
            var claims = new[]
            {
                    new Claim("sub", user.Id.ToString()),
                    new Claim("userName", user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisVeryStrongKeyTOSECUREMYAPIDSDSDSADFSDVSDF"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "TMS Api",
                audience: "TMS Frontend",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
