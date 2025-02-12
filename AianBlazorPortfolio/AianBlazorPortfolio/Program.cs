using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this if needed
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services for API endpoints and controllers.
builder.Services.AddControllers();

// Optionally, add additional services
builder.Services.AddSingleton<EmailService>();      // Your email service implementation
builder.Services.AddSingleton<TestimonialService>();  // Service to store/manage testimonials

// Register the DbContext using SQL Server.
builder.Services.AddDbContext<TestimonialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure error handling and HTTPS.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
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

// Map Blazor WebAssembly endpoints (if hosting client assets here).
app.MapFallbackToFile("index.html");

app.Run();
