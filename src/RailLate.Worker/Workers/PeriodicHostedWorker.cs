using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RailLate.Worker.Tasks;

namespace RailLate.Worker.Workers;

public class PeriodicHostedWorker<TService>() : BackgroundService where TService : IPeriodicTask
{
    private readonly ILogger<PeriodicHostedWorker<TService>> _logger;
    private readonly IServiceScopeFactory _factory;
    private readonly TimeSpan _period = TimeSpan.FromMinutes(30); //TODO add the possibility to set Cron parameters per task
    private int _executionCount; //TODO add the tables in database to persists the execution count
    
    public PeriodicHostedWorker(ILogger<PeriodicHostedWorker<TService>> logger, IServiceScopeFactory factory) : this()
    {
        _logger = logger;
        _factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(_period);
        while (
            !stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            { 
                await using var asyncScope = _factory.CreateAsyncScope(); 
                var service = asyncScope.ServiceProvider.GetRequiredService<TService>();
                
                if (service.IsEnabled)
                {
                    await service.ExecuteTaskAsync(stoppingToken);
                    _executionCount++;
                    _logger.LogInformation(
                        $"Executed PeriodicHostedService - Count: {_executionCount}");
                }
                else
                {
                   _logger.LogInformation(
                        "Skipped PeriodicHostedService");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(
                    $"Failed to execute PeriodicHostedService with exception message {ex.Message}.");
            }
        }
    }
}