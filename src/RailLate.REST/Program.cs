using AspNetCoreRateLimit;
using Autofac.Extensions.DependencyInjection;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using RailLate.Application.Services.Realtime;
using RailLate.Infrastructure.DatabaseContext;
using RailLate.REST;
using RailLate.Shared.Caching;
using RailLate.Worker;
using RailLate.Worker.Services;
using RailLate.Worker.Tasks;
using RailLate.Worker.Tasks.PlanningData;
using RailLate.Worker.Tasks.Realtime;
using RailLate.Worker.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddCors(p => p.AddPolicy("cors-app", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IRealTimeGtfsService, RealTimeGtfsService>();

builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddSingleton<ITaskService, TaskService>();

builder.Services.AddSingleton<IGtfsDataTask, GtfsDataTask>();
builder.Services.AddSingleton<ISqlSyncTask, PlanningDataSyncTask>();
builder.Services.AddSingleton<ISqlSyncTask, RealtimeDataSyncTask>();
builder.Services.AddSingleton<IPeriodicTask>(provider => provider.GetRequiredService<IGtfsDataTask>());
builder.Services.AddSingleton<IPeriodicTask>(provider => provider.GetRequiredService<ISqlSyncTask>());

builder.Services.AddSingleton<PeriodicHostedWorker<IGtfsDataTask>>();
builder.Services.AddSingleton<PeriodicHostedWorker<ISqlSyncTask>>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<PeriodicHostedWorker<IGtfsDataTask>>());
builder.Services.AddHostedService(provider => provider.GetRequiredService<PeriodicHostedWorker<ISqlSyncTask>>());

builder.Services.AddSingleton<ITaskManager>(provider =>
{
    var tasks = provider.GetServices<IPeriodicTask>();
    return new TaskManager(tasks);
});

builder.Services.AddDbContext<EfContext>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"), 
        sqlserverOptions => sqlserverOptions.CommandTimeout(3600));
});

builder.Services.ConfigureCaching(builder.Configuration);
builder.Services.ConfigureRateLimiting();
builder.Services.AddHttpContextAccessor();
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(RailLate.Application.AssemblyReference.Assembly));

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();
app.MapHealthChecks("/health");
app.UseCors("cors-app");
app.UseHttpsRedirection(); 
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<RealTimeGtfsService>();

app.Run();

//This enables to use WebApplicationFactory for smoke testing
public abstract partial class Program {}