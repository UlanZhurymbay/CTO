using CTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.PreferenseSerivces
{
    public class AppStorage : IStorage
    {
        public bool ContainsKey(string key)
        {
            return Preferences.ContainsKey(key);
        }

        public void Set(string key, string value)   
        {
            Preferences.Set(key, value);
        }   
        public string Get(string key)   
        {
            return Preferences.Get(key, string.Empty);
        }
        public void SetUser(User user)   
        {
            Clear();
            Preferences.Set(nameof(User.Name), user.Name);
            Preferences.Set(nameof(User.Email), user.Email);
            Preferences.Set(nameof(User.Id), user.Id.ToString());
            Preferences.Set(nameof(User.PhoneNumber), user.PhoneNumber);
        }

        public void Clear()
        {
            Preferences.Clear();
        }
    }
}
