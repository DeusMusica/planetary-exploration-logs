using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataSeeder>();

// Setting up the database context
builder.Services.AddDbContext<PlanetExplorationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PlanetaryExplorationLogsApiDatabase")));

// Allowing CORS for all origins, headers, and methods so your Angular app can call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Allow requests from any origin
               .AllowAnyHeader() // Allow any HTTP headers
               .AllowAnyMethod(); // Allow any HTTP methods (GET, POST, etc.)
    });
});

var app = builder.Build();

// Apply the CORS policy
app.UseCors("AllowAllOrigins");

using (var scope = app.Services.CreateScope())
{
    // Apply pending migrations
    var dbContext = scope.ServiceProvider.GetRequiredService<PlanetExplorationDbContext>();
    dbContext.Database.Migrate();

    // Seed the database with initial data
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await dataSeeder.SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
