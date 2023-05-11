using CTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.PreferenseSerivces
{
    public interface IStorage
    {
        void Set(string key, string value);
        bool ContainsKey(string key);
        string Get(string key);
        void SetUser(User user);
        void Clear();
    }
}
