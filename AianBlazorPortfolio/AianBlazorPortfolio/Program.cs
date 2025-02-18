using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Ensure the app listens on port 8080 (bind to all interfaces)
builder.WebHost.UseUrls("http://*:8080");

// Register controllers (including API controller).
builder.Services.AddControllers()
    .AddApplicationPart(typeof(AianBlazorPortfolio.Components.Controller.TestimonialController).Assembly);

// Register additional services.
builder.Services.AddSingleton<EmailService>();

// Register TestimonialService as Scoped because it depends on the scoped DbContext.
builder.Services.AddScoped<TestimonialService>();

// Register the DbContext using SQL Server.
builder.Services.AddDbContext<TestimonialDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TestimonialDbContext>();
    dbContext.Database.EnsureCreated();
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