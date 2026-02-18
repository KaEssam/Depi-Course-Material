using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.core.Entites;

namespace TMS.App.Interface
{
   public interface IUserRepository
    {
        Task<User> CreateUser(User user);

        Task<User?> GetUser(string password, string userName);
    }
}
