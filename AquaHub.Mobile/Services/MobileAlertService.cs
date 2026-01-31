using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace AquaHub.Mobile.Services
{
    public class MobileAlertService : IMobileAlertService
    {
        public async Task ShowAlertAsync(string title, string message)
        {
            // Use MainPage for displaying alerts
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, "OK");
            }
        }
    }
}
