using System.Threading.Tasks;

namespace AquaHub.Mobile.Services
{
    public interface IMobileAlertService
    {
        Task ShowAlertAsync(string title, string message);
    }
}
