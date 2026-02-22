using Dotnet_API_17.Entities.Models;

namespace Dotnet_API_17.Helper.JwtHelper
{
    public interface IJwtHelper
    {
        public string GenerateToken(User user);
    }
}
