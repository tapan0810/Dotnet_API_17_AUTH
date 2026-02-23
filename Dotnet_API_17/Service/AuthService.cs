using Dotnet_API_17.Data;
using Dotnet_API_17.Entities.Dtos;
using Dotnet_API_17.Entities.Models;
using Dotnet_API_17.Helper.JwtHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Dotnet_API_17.Service
{
    public class AuthService(AuthDbContext _context,IJwtHelper jwtHelper) : IAuthService
    {
        public async Task<string> Login(LoginDto login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(X => X.Username == login.Username);
            if (user is null)
            {
                return null;
            }

            if (user.Username != login.Username)
                return null;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, login.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            string token = jwtHelper.GenerateToken(user);

            return token;
        }

        public async Task<User> Register(RegisterDto register)
        {
           if(await _context.Users.AnyAsync(x =>x.Username == register.Username))
            {
                return null;
            }

            var user = new User { Username = register.Username, Role = register.Role ?? "User" };

            var HasPassword = new PasswordHasher<User>().HashPassword(user,register.Password);

            user.Username = register.Username;
            user.PasswordHash = HasPassword;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }
    }
}
