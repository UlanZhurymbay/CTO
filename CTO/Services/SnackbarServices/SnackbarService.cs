using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Services.SnackbarServices
{
    public class SnackbarService : ISnackbar
    {
        public void Message(string message)
        {
            Snackbar.Make(message).Show();
        }
    }
}
