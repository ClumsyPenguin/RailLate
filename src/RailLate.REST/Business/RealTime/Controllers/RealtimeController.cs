using GrpcRealTimeGtfsClient;
using Microsoft.AspNetCore.Mvc;
using RailLate.Application.Services.Realtime;

namespace RailLate.REST.Business.RealTime.Controllers;

[Route("[controller]")]
public class RealtimeController : ControllerBase
{
    private readonly IRealTimeGtfsService _realTimeGtfsService;
    
    private string RealTimeUrl =>
        "https://sncb-opendata.hafas.de/gtfs/realtime/c21ac6758dd25af84cca5b707f3cb3de";

    public RealtimeController(IRealTimeGtfsService realTimeGtfsService)
    {
        _realTimeGtfsService = realTimeGtfsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRealTimeFeedAsync(CancellationToken cancellationToken)
    {
        var resultBytes = await _realTimeGtfsService.FetchGtfsRealtimeDataAsync(RealTimeUrl, cancellationToken);
        var result = _realTimeGtfsService.ParseGtfsRealtimeData(resultBytes);
        return Ok(result);
    }
}