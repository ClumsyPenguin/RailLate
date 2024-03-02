using Microsoft.EntityFrameworkCore;
using RailLate.Domain.Entities;

namespace RailLate.Infrastructure.DatabaseContext;

public class EfContext : DbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }
    
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<CalendarDate> CalendarDates { get; set; }
    public DbSet<FareAttribute> FareAttributes { get; set; }
    public DbSet<FareRule> FareRules { get; set; }
    public DbSet<FeedInfo> FeedInfos { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<StopTime> StopTimes { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}