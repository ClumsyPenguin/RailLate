using GrpcRealTimeGtfsClient;
using RailLate.Shared.Caching;

namespace RailLate.Application.Services.Realtime;

public interface IRealTimeGtfsService
{
    public Task<FeedMessage> FetchGtfsRealtimeDataAsync(string url, CancellationToken cancellationToken);
}

public class RealTimeGtfsService : IRealTimeGtfsService
{
    [Cache(5)]
    public async Task<FeedMessage> FetchGtfsRealtimeDataAsync(string url, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetByteArrayAsync(url, cancellationToken);
        return ParseGtfsRealtimeData(response);
    }
    
    [Cache(5)]
    private FeedMessage ParseGtfsRealtimeData(byte[] data)
    {
        var feedMessage = FeedMessage.Parser.ParseFrom(data);
        return feedMessage;
    }
}