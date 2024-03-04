using Microsoft.EntityFrameworkCore;
using RailLate.Infrastructure.DatabaseContext;
using Testcontainers.MsSql;
using Agency = RailLate.Domain.Entities.Agency;

namespace RailLate.Test.Integration.Infrastructure;

public abstract class IntegrationTest : IAsyncLifetime
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

    internal EfContext GetContext()
    {
        var connectionString = _msSql.GetConnectionString();
        var options = new DbContextOptionsBuilder<EfContext>()
            .UseSqlServer(connectionString)
            .Options;
        return new EfContext(options);
    }

    internal void SeedData()
    {
        using var context = GetContext();
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
        
        //TODO Add more seed data here
    }
}