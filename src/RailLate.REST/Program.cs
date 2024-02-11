using AspNetCoreRateLimit;
using RailLate.Infrastructure;
using RailLate.REST;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("cors-app", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));

builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimiting();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddAutoMapper(AssemblyReference.Assembly);
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