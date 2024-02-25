using System.Reflection;
using System.Reflection.Metadata;
using GTFS;

namespace RailLate.Worker.Tasks;

public interface ISncbGtfsDataTask : IPeriodicTask
{
    public Task<GTFSFeed> GetPlanningDataAsync(CancellationToken cancellationToken);
}

public class SncbGtfsDataTask : ISncbGtfsDataTask
{
    private readonly string _gtfsFolderPath = "Data";
    private readonly string _sncbGtfsUrl =
        "https://sncb-opendata.hafas.de/gtfs/static/c21ac6758dd25af84cca5b707f3cb3de";
    private readonly HttpClient _httpClient = new();
    
    public bool IsEnabled { get; set; }

    public SncbGtfsDataTask()
    {
        _gtfsFolderPath = Path.GetFullPath(Path.Combine(AssemblyReference.Assembly.Location, "../../../../../", "RailLate.Worker", "Data"));
    }
    
    public async Task<GTFSFeed> GetPlanningDataAsync(CancellationToken cancellationToken)
    {
        var zipFilePath = await DownloadFeedAsync(_sncbGtfsUrl, cancellationToken).ConfigureAwait(false);
        var reader = new GTFSReader<GTFSFeed>();
        var feed = reader.Read(zipFilePath);
        return feed;
    }
    
    private async Task<string> DownloadFeedAsync(string feedUrl, CancellationToken cancellationToken)
    {
        var zipFileName = Path.GetFileName(feedUrl);
        var zipFilePath = Path.Combine(_gtfsFolderPath, zipFileName + ".zip");
        
        Directory.CreateDirectory(_gtfsFolderPath);

        using var response = await _httpClient.GetAsync(feedUrl, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        if (response.Content.Headers.ContentLength == 0)
        {
            throw new Exception("Downloaded file is empty.");
        }

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await using var fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        await stream.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);

        if (new FileInfo(zipFilePath).Length == 0)
        {
            throw new Exception("Saved file is empty.");
        }

        return zipFilePath;
    }

    public async Task ExecuteTaskAsync(CancellationToken stoppingToken)
    {
        await GetPlanningDataAsync(stoppingToken);
    }
}