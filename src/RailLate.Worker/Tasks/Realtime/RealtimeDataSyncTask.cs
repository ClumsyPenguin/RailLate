using GrpcRealTimeGtfsClient;
namespace RailLate.Worker.Tasks.Realtime;

public class RealtimeDataSyncTask : ISqlSyncTask
{
    private string RealTimeUrl =>
        "https://sncb-opendata.hafas.de/gtfs/realtime/c21ac6758dd25af84cca5b707f3cb3de";
    
    public async Task ExecuteTaskAsync(CancellationToken stoppingToken)
    {
        await SyncSqlAsync(stoppingToken);
    }

    public bool IsEnabled { get; set; }
    public async Task SyncSqlAsync(CancellationToken cancellationToken)
    {
        var feedMessage = await FetchFeedMessageAsync(cancellationToken);

        
    }
    
    private FeedMessage ParseGtfsRealtimeData(byte[] data)
    {
        var feedMessage = FeedMessage.Parser.ParseFrom(data);
        return feedMessage;
    }
    
    private async Task<FeedMessage> FetchFeedMessageAsync(CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetByteArrayAsync(RealTimeUrl, cancellationToken);
        return ParseGtfsRealtimeData(response);
    }
}