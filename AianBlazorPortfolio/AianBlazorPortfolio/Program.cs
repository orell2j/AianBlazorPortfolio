using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this if needed
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register controllers (including your API controller).
builder.Services.AddControllers()
    .AddApplicationPart(typeof(AianBlazorPortfolio.Components.Controller.TestimonialController).Assembly);

// Register additional services.
builder.Services.AddSingleton<EmailService>();

// IMPORTANT: Register TestimonialService as Scoped because it depends on the scoped DbContext.
builder.Services.AddScoped<TestimonialService>();

// Register the DbContext using SQL Server.
builder.Services.AddDbContext<TestimonialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
app.UseStaticFiles();  // Serves files from wwwroot (client assets)
app.UseRouting();

app.MapControllers();  // Routes API calls (e.g., /api/testimonial/submit)
app.MapFallbackToFile("index.html");  // Serves the client app for unmatched routes

app.Run();