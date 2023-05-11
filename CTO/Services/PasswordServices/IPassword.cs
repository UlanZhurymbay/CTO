using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.PasswordServices
{
    public interface IPassword
    {
        string HashToString(string password);
    }
}
