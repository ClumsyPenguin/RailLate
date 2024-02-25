namespace RailLate.Worker.Tasks;

public interface ISqlSyncTask : IPeriodicTask
{
    public Task SyncSqlAsync(CancellationToken cancellationToken);
}


public class SqlSyncTask : ISqlSyncTask
{
    public bool IsEnabled { get; set; }
    public async Task ExecuteTaskAsync(CancellationToken stoppingToken)
    {
        await SyncSqlAsync(stoppingToken);
    }
    
    public Task SyncSqlAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();}
}