namespace RailLate.Worker.Tasks;

public interface ISqlSyncTask : IPeriodicTask
{
    public Task SyncSqlAsync(CancellationToken cancellationToken);
}