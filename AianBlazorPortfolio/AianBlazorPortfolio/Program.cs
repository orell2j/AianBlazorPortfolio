using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

// Although the default builder loads environment variables,
// we explicitly add them here to ensure they are available.
builder.Configuration.AddEnvironmentVariables();

// Ensure the app listens on port 8080
if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_URLS")))
{
    builder.WebHost.UseUrls("http://*:8080");
}

// First try to get the connection string from the environment variable
var envConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
// If not found, fall back to the configuration file.
var connectionString = !string.IsNullOrEmpty(envConnectionString)
    ? envConnectionString
    : builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine($"Using connection string: {connectionString}");

// Register controllers (including API controller).
builder.Services.AddControllers()
    .AddApplicationPart(typeof(AianBlazorPortfolio.Components.Controller.TestimonialController).Assembly);

// Register additional services.
builder.Services.AddSingleton<EmailService>();

// Register TestimonialService as Scoped because it depends on the scoped DbContext.
builder.Services.AddScoped<TestimonialService>();

// Register the DbContext using Npgsql (PostgreSQL)
builder.Services.AddDbContext<TestimonialDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Retry logic to wait for the PostgreSQL service to be ready
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TestimonialDbContext>();
    const int maxRetries = 5;
    int retryCount = 0;
    bool dbConnected = false;

    while (retryCount < maxRetries && !dbConnected)
    {
        try
        {
            dbContext.Database.EnsureCreated();
            dbConnected = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection attempt {retryCount + 1} failed: {ex.Message}");
            retryCount++;
            Thread.Sleep(5000); // Wait 5 seconds before trying again
        }
    }

    if (!dbConnected)
    {
        throw new Exception("Unable to connect to the database after multiple attempts.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();