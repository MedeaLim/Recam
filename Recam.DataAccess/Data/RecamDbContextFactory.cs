using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Recam.DataAccess.Data;

namespace Recam.DataAccess;

public class RecamDbContextFactory : IDesignTimeDbContextFactory<RecamDbContext>
{
    public RecamDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecamDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=RecamDb;User Id=sa;Password=RecamPass123;TrustServerCertificate=True;Encrypt=False");

        return new RecamDbContext(optionsBuilder.Options);
    }
}