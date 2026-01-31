using System;
using System.Threading.Tasks;
using AquaHub.Mobile.Services;

namespace AquaHub.Mobile.Tests
{
    public class TokenServiceTest
    {
        public static async Task RunAsync(ITokenService tokenService)
        {
            Console.WriteLine("Testing TokenService...");
            string testToken = "test-token-123";

            await tokenService.StoreTokenAsync(testToken);
            var retrieved = await tokenService.GetTokenAsync();
            Console.WriteLine($"Stored: {testToken}, Retrieved: {retrieved}");

            if (retrieved != testToken)
                throw new Exception("TokenService failed to retrieve the correct token.");

            await tokenService.ClearTokenAsync();
            var cleared = await tokenService.GetTokenAsync();
            Console.WriteLine($"After clear, token: {cleared}");

            if (cleared != null)
                throw new Exception("TokenService failed to clear the token.");

            Console.WriteLine("TokenService test passed.");
        }
    }
}
