using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using ZiggyCreatures.Caching.Fusion;

namespace RailLate.Shared.Caching;

public static class ServiceExtensions
{
    public static void ConfigureCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        
        var redisConnectionString = configuration.GetConnectionString("Redis") ?? throw new InvalidOperationException("Redis connection needs to be specified");
        
        IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisConnectionString);

        services.AddSingleton<IConnectionMultiplexer>(_ => multiplexer);

        services.AddFusionCache()
            .WithDefaultEntryOptions(new FusionCacheEntryOptions
            {
                IsFailSafeEnabled = true,
                FailSafeMaxDuration = TimeSpan.FromMinutes(5),
                FailSafeThrottleDuration = TimeSpan.FromMinutes(1),
                JitterMaxDuration = TimeSpan.FromSeconds(2)
            })
            .WithDistributedCache(new RedisCache(new RedisCacheOptions
            {
                ConnectionMultiplexerFactory = () => Task.FromResult(multiplexer)
            }));
    }
}