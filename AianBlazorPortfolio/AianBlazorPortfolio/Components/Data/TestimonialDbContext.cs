using Microsoft.EntityFrameworkCore;
using AianBlazorPortfolio.Components.Models;

namespace AianBlazorPortfolio.Components.Data
{
    public class TestimonialDbContext : DbContext
    {
        public TestimonialDbContext(DbContextOptions<TestimonialDbContext> options)
            : base(options)
        {
        }

        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
