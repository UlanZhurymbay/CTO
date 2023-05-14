using CommunityToolkit.Maui.Alerts;
using CTO.Models;
using CTO.Models.Data;
using CTO.Services.PasswordServices;
using CTO.Services.PreferenseSerivces;
using CTO.Services.SnackbarServices;

namespace CTO.Services.AuthServices
{
    public class AuthService : IAuth
    {
        private readonly CTOContext _context;
        private readonly ISnackbar _snackbar;
        private readonly IPassword _password;
        private readonly IStorage _storage;

        public AuthService(IPassword password, CTOContext context, IStorage storage, ISnackbar snackbar)
        {
            _snackbar = snackbar;
            _storage = storage;
            _context = context;
            _password = password;
        }

        public async Task<bool> EditAsync(User model, string email)
        {
            var user = await _context.GetAsync<User>(u => u.Email == email);
            var userCheck = await _context.GetAsync<User>(u => u.Email == model.Email && u.Email != email);
            if (userCheck != null)
            {
                _snackbar.Message("Такой логин уже существует");
                return false;
            }
            user.PhoneNumber = model.PhoneNumber;
            user.Name = model.Name;
            user.Email = model.Email;
            await _context.UpdateAsync(user);
            _storage.SetUser(user);
            return true;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _context.GetAsync<User>(u => u.Email == email);
            if (user?.Password == _password.HashToString(password))
            {
                _storage.SetUser(user);
                Preferences.Set(nameof(User.PhoneNumber), user.PhoneNumber);
                return true;
            }
            _snackbar.Message("Неверный логин или пароль");
            return false;
        }

        public void Logout()
        {
            _storage.Clear();
        }

        public async Task<bool> RegisterAsync(User model)
        {
            var user = await _context.GetAsync<User>(u => u.Email == model.Email);
            if (user != null)
            {
                _snackbar.Message("Такой логин уже существует");
                return false;
            }
            var newUser = new User()
            {
                Email = model.Email,
                Password = _password.HashToString(model.Password),
                Name = model.Name,
            };
            await _context.AddAsync(newUser);
            _storage.SetUser(newUser);
            return true;
        }
    }
}
