using GrpcRealTimeGtfsClient;
namespace RailLate.Application.Services.Realtime;

//TODO Add gRPC typed-client
//TODO Cleaner handling of the realtime data errors
public interface IRealTimeGtfsService
{
    public Task<byte[]> FetchGtfsRealtimeDataAsync(string url, CancellationToken cancellationToken);
    public FeedMessage ParseGtfsRealtimeData(byte[] data);
}

public class RealTimeGtfsService : IRealTimeGtfsService
{
    public async Task<byte[]> FetchGtfsRealtimeDataAsync(string url, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetByteArrayAsync(url, cancellationToken);
        return response;
    }
    
    public FeedMessage ParseGtfsRealtimeData(byte[] data)
    {
        var feedMessage = FeedMessage.Parser.ParseFrom(data);
        return feedMessage;
    }
}