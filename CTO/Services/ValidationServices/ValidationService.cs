using CommunityToolkit.Maui.Alerts;
using CTO.Models;
using CTO.Services.SnackbarServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTO.Services.ValidationServices
{
    public class ValidationService : IValidation
    {
        private const string ValidEmailPattern = "^\\S+@\\S+\\.\\S+$";
        private readonly ISnackbar _snackbar;

        public ValidationService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public bool CheckUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                _snackbar.Message("Неверный email");
                return false;
            }
            if (string.IsNullOrEmpty(user.Name))
            {
                _snackbar.Message("Неверный имя");
                return false;
            }
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                _snackbar.Message("Неверный phone");
                return false;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                _snackbar.Message("Неверный password");
                return false;
            }
            return true;
        }
        public bool CheckUserWithoutPassword(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                _snackbar.Message("Неверный email");
                return false;
            }
            var result = new Regex(ValidEmailPattern, RegexOptions.IgnoreCase).IsMatch(user.Email);
            if (!result)
            {
                _snackbar.Message("Неверный email");
                return false;
            }
            if (string.IsNullOrEmpty(user.Name))
            {
                _snackbar.Message("Неверный имя");
                return false;
            }
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                _snackbar.Message("Неверный phone");
                return false;
            }


            return true;
        }
        public bool CheckEmailAndPassword(string email, string password)
        {

            if (string.IsNullOrEmpty(email))
            {
                _snackbar.Message("Неверный email");
                return false;
            }
            var result = new Regex(ValidEmailPattern, RegexOptions.IgnoreCase).IsMatch(email);
            if (!result)
            {
                _snackbar.Message("Неверный email");
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                _snackbar.Message("Неверный password");
                return false;
            }
            return true;
        }
    }
}
