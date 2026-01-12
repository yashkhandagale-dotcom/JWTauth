using UserCRUDandJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace UserCRUDandJWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();

        // 🔹 Refresh Tokens (NEW)
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    }
}
