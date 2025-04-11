using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BiddingManagementSystem.Infrastructure.Persistence;
using BiddingManagementSystem.Domain.Entities;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Replace this with your actual connection string
        var connectionString = "Server =.; Database = BiddingDB; User Id = sa; Password = sa123456; Integrated Security = True; TrustServerCertificate = True; ";

        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
