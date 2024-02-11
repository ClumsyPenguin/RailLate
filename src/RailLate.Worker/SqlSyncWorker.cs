using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RailLate.Worker;

public class SqlSyncWorker(ILogger<SqlSyncWorker> logger) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}