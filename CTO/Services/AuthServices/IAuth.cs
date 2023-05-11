using CTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.AuthServices
{
    public interface IAuth
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> EditAsync(User user, string email);
        void Logout();
        Task<bool> RegisterAsync(User user);
    }
}
