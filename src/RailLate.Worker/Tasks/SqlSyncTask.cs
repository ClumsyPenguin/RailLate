using System.Linq.Expressions;
using GTFS;
using GTFS.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using RailLate.Domain.Entities;
using RailLate.Infrastructure.DatabaseContext;
using RailLate.Infrastructure.Extensions;
using Agency = RailLate.Domain.Entities.Agency;
using Calendar = RailLate.Domain.Entities.Calendar;
using CalendarDate = RailLate.Domain.Entities.CalendarDate;
using FareAttribute = RailLate.Domain.Entities.FareAttribute;
using FareRule = RailLate.Domain.Entities.FareRule;
using Route = RailLate.Domain.Entities.Route;
using Stop = RailLate.Domain.Entities.Stop;
using StopTime = RailLate.Domain.Entities.StopTime;
using Transfer = RailLate.Domain.Entities.Transfer;
using Trip = RailLate.Domain.Entities.Trip;

namespace RailLate.Worker.Tasks;

public interface ISqlSyncTask : IPeriodicTask
{
    public Task SyncSqlAsync(CancellationToken cancellationToken);
}


public class SqlSyncTask(IServiceProvider serviceProvider) : ISqlSyncTask
{
    public bool IsEnabled { get; set; }

    public async Task ExecuteTaskAsync(CancellationToken stoppingToken)
    {
        await SyncSqlAsync(stoppingToken);
    }
    
    public async Task SyncSqlAsync(CancellationToken cancellationToken)
    {
       var feed = FetchGtfsFeedAsync();
       
       await SyncTable<GTFS.Entities.Agency, Agency>(
           feed.Agencies, 
           newEntity => existingEntity => existingEntity.Name == newEntity.Name, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Calendar, Calendar>(
           feed.Calendars, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.CalendarDate, CalendarDate>(
           feed.CalendarDates, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareAttribute, FareAttribute>(
           feed.FareAttributes, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareRule, FareRule>(
           feed.FareRules, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Route, Route>(
           feed.Routes, 
           newEntity => existingEntity => existingEntity.LongName == newEntity.LongName, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Stop, Stop>(
           feed.Stops, 
           newEntity => existingEntity => existingEntity.Code == newEntity.Code, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.StopTime, StopTime>(
           feed.StopTimes, 
           newEntity => existingEntity => existingEntity.TripId == newEntity.TripId 
                                       && existingEntity.StopId == newEntity.StopId
                                       && existingEntity.ArrivalTime == newEntity.ArrivalTime
                                       && existingEntity.DepartureTime == newEntity.DepartureTime, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Agency, Agency>(
           feed.Agencies, 
           newEntity => existingEntity => existingEntity.Name == newEntity.Name, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Calendar, Calendar>(
           feed.Calendars, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.CalendarDate, CalendarDate>(
           feed.CalendarDates, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareAttribute, FareAttribute>(
           feed.FareAttributes, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareRule, FareRule>(
           feed.FareRules, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Route, Route>(
           feed.Routes, 
           newEntity => existingEntity => existingEntity.LongName == newEntity.LongName, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Stop, Stop>(
           feed.Stops, 
           newEntity => existingEntity => existingEntity.Code == newEntity.Code, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.StopTime, StopTime>(
           feed.StopTimes, 
           newEntity => existingEntity => existingEntity.TripId == newEntity.TripId 
                                       && existingEntity.StopId == newEntity.StopId
                                       && existingEntity.ArrivalTime == newEntity.ArrivalTime
                                       && existingEntity.DepartureTime == newEntity.DepartureTime, 
           cancellationToken);     await SyncTable<GTFS.Entities.Agency, Agency>(
           feed.Agencies, 
           newEntity => existingEntity => existingEntity.Name == newEntity.Name, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Calendar, Calendar>(
           feed.Calendars, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.CalendarDate, CalendarDate>(
           feed.CalendarDates, 
           newEntity => existingEntity => existingEntity.ServiceId == newEntity.ServiceId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareAttribute, FareAttribute>(
           feed.FareAttributes, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.FareRule, FareRule>(
           feed.FareRules, 
           newEntity => existingEntity => existingEntity.FareId == newEntity.FareId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Route, Route>(
           feed.Routes, 
           newEntity => existingEntity => existingEntity.LongName == newEntity.LongName, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Stop, Stop>(
           feed.Stops, 
           newEntity => existingEntity => existingEntity.Code == newEntity.Code, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.StopTime, StopTime>(
           feed.StopTimes, 
           newEntity => existingEntity => existingEntity.TripId == newEntity.TripId 
                                       && existingEntity.StopId == newEntity.StopId
                                       && existingEntity.ArrivalTime == newEntity.ArrivalTime
                                       && existingEntity.DepartureTime == newEntity.DepartureTime, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Transfer, Transfer>(
           feed.Transfers, 
           newEntity => existingEntity => existingEntity.FromStopId == newEntity.FromStopId 
                                       && existingEntity.ToStopId == newEntity.ToStopId, 
           cancellationToken);
       
       await SyncTable<GTFS.Entities.Trip, Trip>(
           feed.Trips, 
           newEntity => existingEntity => existingEntity.ShortName == newEntity.ShortName,
           cancellationToken);
    }
    
    private async Task SyncTable<TGtfs, TDb>(IEnumerable<TGtfs> gtfsEntities, Func<TDb, Expression<Func<TDb, bool>>> predicateBuilder, CancellationToken cancellationToken)
        where TDb : GtfsEntity, new() where TGtfs : GTFSEntity
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EfContext>();
        
        TypeAdapterConfig<TGtfs, TDb>.NewConfig()
            .Map(dest => dest.Id, src => Guid.NewGuid()); 
        
        var dbEntities = gtfsEntities.Adapt<List<TDb>>();
        
        await dbContext.Set<TDb>().AddRangeIfNotExistsAsync(
            dbEntities,
            predicateBuilder,
            cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private GTFSFeed FetchGtfsFeedAsync()
    {
        var zipFileFolder = Path.GetFullPath(Path.Combine(AssemblyReference.Assembly.Location, "../../../../../", "RailLate.Worker", "Data"));
        var zipFileName = Directory.GetFiles(zipFileFolder).FirstOrDefault(newEntity => newEntity.EndsWith(".zip"));
        if(zipFileName == null)
        {
            throw new Exception("No GTFS file found.");
        }
        var zipFilePath = Path.Combine(zipFileFolder, zipFileName);
        var reader = new GTFSReader<GTFSFeed>();
        return reader.Read(zipFilePath);
    }
}