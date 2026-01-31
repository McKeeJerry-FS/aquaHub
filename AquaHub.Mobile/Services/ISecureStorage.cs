using System.Threading.Tasks;

namespace AquaHub.Mobile.Services
{
    public interface ISecureStorage
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
        Task RemoveAsync(string key);
    }
}
