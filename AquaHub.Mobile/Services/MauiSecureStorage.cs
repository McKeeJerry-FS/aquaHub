using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace AquaHub.Mobile.Services
{
    public class MauiSecureStorage : ISecureStorage
    {
        public async Task SetAsync(string key, string value)
        {
            await SecureStorage.Default.SetAsync(key, value);
        }

        public async Task<string> GetAsync(string key)
        {
            return await SecureStorage.Default.GetAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            SecureStorage.Default.Remove(key);
            await Task.CompletedTask;
        }
    }
}
