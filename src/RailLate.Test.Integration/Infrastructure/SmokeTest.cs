using Microsoft.AspNetCore.Mvc.Testing;

namespace RailLate.Test.Integration.Infrastructure;

[Trait("Category", "Integration")]
public abstract class SmokeTest : IClassFixture<ApiWebApplicationFactory>, IDisposable
{
    protected readonly HttpClient _client;

    protected SmokeTest(ApiWebApplicationFactory factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost:7190/"),
            
        });
    }
    
    public void Dispose()
    {
    }
}