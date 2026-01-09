using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserCRUDandJWT.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Use your SQL Server connection string here
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=UserManagementAPI;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}
