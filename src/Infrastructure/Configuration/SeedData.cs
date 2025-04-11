// Infrastructure/Configuration/SeedData.cs
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BiddingManagementSystem.Infrastructure.Configuration
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Users.Any()) return; // Already seeded

            // Seed Users
            var admin = new User(
                fullName: "System Admin",
                email: "admin@bms.com",
                passwordHash: BCrypt.Net.BCrypt.HashPassword("Admin123!"), // Use BCrypt for hashing
                role: UserRole.ProcurementOfficer
            );

            var bidder = new User(
                fullName: "Bidder Joe",
                email: "bidder@bms.com",
                passwordHash: BCrypt.Net.BCrypt.HashPassword("Bid123!"),
                role: UserRole.Bidder
            );

            var evaluator = new User(
                fullName: "Evaluator Emma",
                email: "evaluator@bms.com",
                passwordHash: BCrypt.Net.BCrypt.HashPassword("Eval123!"),
                role: UserRole.Evaluator
            );

            await context.Users.AddRangeAsync(admin, bidder, evaluator);

            // Seed Tender
            var tender = new Tender(
                title: "IT Infrastructure Upgrade",
                description: "Upgrade and modernize our internal IT systems.",
                deadline: DateTime.UtcNow.AddDays(15),
                budget: new Money(50000, "USD"),
                category: "IT Services",
                type: "Open",
                location: "Amman"
            );

            await context.Tenders.AddAsync(tender);
            await context.SaveChangesAsync();
        }
    }
}
