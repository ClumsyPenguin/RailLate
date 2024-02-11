using System.ComponentModel;
using GTFS;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RailLate.Worker.Services;

namespace RailLate.Worker;

public class GtfsFetchWorker(ILogger<GtfsFetchWorker> logger, ISncbGtfsDataService sncbGtfsDataService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("GTFS Fetch Service running.");
        using PeriodicTimer timer = new(TimeSpan.FromSeconds(1000));

        var feed =  await sncbGtfsDataService.GetPlanningDataAsync(stoppingToken).ConfigureAwait(false);
        
        try
        {
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                logger.LogInformation("Timed Hosted Service is working. Fetching newest GTFS planning data.");
                
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("GTFS Fetch Service is stopping.");
        }
    }
}