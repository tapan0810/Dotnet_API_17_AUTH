using Dotnet_API_17.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_17.Data
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Students> Students => Set<Students>();
    }
}
