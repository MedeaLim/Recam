using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recam.Models.Entities;

namespace Recam.DataAccess.Data;

public class RecamDbContext : IdentityDbContext<ApplicationUser>
{
    public RecamDbContext(DbContextOptions<RecamDbContext> options)
        : base(options)
    {
    }

    public DbSet<ListingCase> ListingCases { get; set; }
    

    public DbSet<MediaAsset> MediaAssets { get; set; }

    public DbSet<Agent> Agents { get; set; }

    public DbSet<StatusHistory> StatusHistories { get; set; }

    public DbSet<CaseContact> CaseContacts { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ListingCase>()
        .Property(l => l.Price)
        .HasPrecision(18, 2);

    modelBuilder.Entity<CaseContact>()
        .HasOne(c => c.ListingCase)
        .WithMany(l => l.CaseContacts)
        .HasForeignKey(c => c.ListingId)
        .OnDelete(DeleteBehavior.Cascade);
}
}

