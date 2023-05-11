using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.PasswordServices
{
    public class PasswordService : IPassword
    {
        public string HashToString(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToHexString(SHA256.HashData(bytes));
        }
    }
}
