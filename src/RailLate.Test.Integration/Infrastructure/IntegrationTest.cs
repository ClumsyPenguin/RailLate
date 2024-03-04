using Microsoft.EntityFrameworkCore;
using RailLate.Infrastructure.DatabaseContext;
using Testcontainers.MsSql;
using Agency = RailLate.Domain.Entities.Agency;

namespace RailLate.Test.Integration.Infrastructure;

public class IntegrationTest : IAsyncLifetime
{
    private readonly MsSqlContainer _msSql = new MsSqlBuilder()
        .Build();
    
    public Task InitializeAsync()
    {
        return _msSql.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _msSql.DisposeAsync().AsTask();
    }
    
    [Fact]
    public void ShouldReturnTwoCustomers()
    {
        var connectionString = _msSql.GetConnectionString();
        var options = new DbContextOptionsBuilder<EfContext>()
            .UseSqlServer(connectionString)
            .Options;
        using var context = new EfContext(options);
        context.Database.EnsureCreated();
        
        context.Agencies.Add(new Agency
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test Agency",
            URL = "test-agency.com",
            Timezone = "Europe/Stockholm",
            LanguageCode = "en",
            Phone = "+46 123 456 789",
            FareURL = "test-agency.com/fare",
            Email = "info@testagency.com"
        });
        context.SaveChanges();
        
        var agencies = context.Agencies.ToList();
    }
}