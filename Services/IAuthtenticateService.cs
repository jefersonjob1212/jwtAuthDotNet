using jwtAuthDotNet.Models;

namespace jwtAuthDotNet.Services
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}