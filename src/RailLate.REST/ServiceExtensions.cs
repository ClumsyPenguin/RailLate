using AspNetCoreRateLimit;
using Marvin.Cache.Headers;
using Microsoft.OpenApi.Models;

namespace RailLate.REST;

public static class ServiceExtensions
{
    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        var rateLimitRules = new List<RateLimitRule>
        {
            new()
            {
                Endpoint = "*",
                Limit = 15,
                Period = "30s"
            },
        };
        services.Configure<IpRateLimitOptions>(opt =>
        {
            opt.GeneralRules = rateLimitRules;
        });
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    }
    
    
    public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
    {
        services.AddResponseCaching();
        services.AddHttpCacheHeaders(
            (expirationOpt) =>
            {
                expirationOpt.MaxAge = 65;
                expirationOpt.CacheLocation = CacheLocation.Private;
            },
            validationOpt =>
            {
                validationOpt.MustRevalidate = true;
            }
        );
    }
    
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My Volcano API",
                Version = "v1"
            });
            //c.EnableAnnotations();
        });
    } 
}