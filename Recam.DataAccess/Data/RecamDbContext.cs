using Microsoft.EntityFrameworkCore;
using Recam.Models.Entities;

namespace Recam.DataAccess.Data;

public class RecamDbContext : DbContext
{
    public RecamDbContext(DbContextOptions<RecamDbContext> options)
        : base(options)
    {
    }

    public DbSet<ListingCase> ListingCases { get; set; }

    public DbSet<MediaAsset> MediaAssets { get; set; }

    public DbSet<Agent> Agents { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<StatusHistory> StatusHistories { get; set; }
}