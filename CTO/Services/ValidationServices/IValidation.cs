using CTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.ValidationServices
{
    public interface IValidation
    {
        bool CheckUser(User user);
        bool CheckUserWithoutPassword(User user);
        bool CheckEmailAndPassword(string email, string password);
    }
}
