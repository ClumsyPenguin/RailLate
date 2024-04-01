using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RailLate.Test.Integration.Infrastructure;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    public IConfiguration Configuration { get; private set; }
    public static IServiceProvider? ServiceProvider { get; set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            // Configuration = new ConfigurationBuilder()
            //     .AddJsonFile("integrationsettings.json")
            //     .Build();
            //
            // config.AddConfiguration(Configuration);
        });

        builder.ConfigureTestServices(services =>
        {
            ServiceProvider = services.BuildServiceProvider();
        });
    }
}