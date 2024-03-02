using AspNetCoreRateLimit;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RailLate.Infrastructure;
using RailLate.Infrastructure.DatabaseContext;
using RailLate.REST;
using RailLate.Worker;
using RailLate.Worker.Services;
using RailLate.Worker.Tasks;
using RailLate.Worker.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("cors-app", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddSingleton<ITaskService, TaskService>();

builder.Services.AddSingleton<IGtfsDataTask, GtfsDataTask>();
builder.Services.AddSingleton<ISqlSyncTask, SqlSyncTask>();
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

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));

builder.Services.AddDbContext<EfContext>((serviceProvider, options) =>
{
    var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    options.UseSqlServer(dbSettings.ConnectionString);
});

builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimiting();
builder.Services.AddHttpContextAccessor();

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
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseAuthorization();
app.MapControllers();

app.Run();