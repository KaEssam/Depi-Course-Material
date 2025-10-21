using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.App.Interface;
using TMS.core.Entites;
using TMS.infra.Data;

namespace TMS.infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUser(string password, string userName)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }
    }
}
