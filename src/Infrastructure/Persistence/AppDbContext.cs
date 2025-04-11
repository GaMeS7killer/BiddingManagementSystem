// Infrastructure/Persistence/AppDbContext.cs
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BiddingManagementSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Tender> Tenders => Set<Tender>();
        public DbSet<Bid> Bids => Set<Bid>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Money value object for Tender.Budget
            modelBuilder.Entity<Tender>().OwnsOne(t => t.Budget);

            // One-to-Many: Tender -> Bids
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.Bids)
                .WithOne(b => b.Tender)
                .HasForeignKey(b => b.TenderId);

            // One-to-Many: User -> Bids
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bids)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            // Seed data later in SeedData.cs
        }
    }
}
