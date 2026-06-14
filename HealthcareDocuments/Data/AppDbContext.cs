using HealthcareDocuments.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareDocuments.Data;

public class AppDbContext : DbContext
{
    public DbSet<Referral> Referrals { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<ExchangeLog> ExchangeLogs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Referral>()
            .HasMany(r => r.Documents)
            .WithOne(d => d.Referral)
            .HasForeignKey(d => d.ReferralId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Referral>()
            .HasMany(r => r.ExchangeLogs)
            .WithOne(e => e.Referral)
            .HasForeignKey(e => e.ReferralId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}