using System.Threading.Tasks;
using AquaHub.Mobile.Services;

namespace AquaHub.Mobile.Services
{
    public interface ITokenService
    {
        Task StoreTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task ClearTokenAsync();
    }

    public class TokenService : ITokenService
    {
        private const string TokenKey = "auth_token";
        private readonly ISecureStorage _secureStorage;

        public TokenService(ISecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }

        public Task StoreTokenAsync(string token) => _secureStorage.SetAsync(TokenKey, token);
        public Task<string?> GetTokenAsync() => _secureStorage.GetAsync(TokenKey);
        public Task ClearTokenAsync() => _secureStorage.RemoveAsync(TokenKey);
    }
}
