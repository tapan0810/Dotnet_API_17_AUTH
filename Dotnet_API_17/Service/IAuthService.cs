using Dotnet_API_17.Entities.Dtos;
using Dotnet_API_17.Entities.Models;

namespace Dotnet_API_17.Service
{
    public interface IAuthService
    {
        public Task<string> Login(LoginDto login);
        public Task<User> Register (RegisterDto register);
    }
}
