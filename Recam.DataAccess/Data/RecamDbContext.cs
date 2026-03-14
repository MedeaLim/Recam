using Microsoft.EntityFrameworkCore;

namespace Recam.DataAccess.Context;

public class RecamDbContext : DbContext
{
    public RecamDbContext(DbContextOptions<RecamDbContext> options)
        : base(options)
    {
    }
}