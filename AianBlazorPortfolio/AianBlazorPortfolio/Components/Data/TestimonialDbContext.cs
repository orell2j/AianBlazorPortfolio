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
        public DbSet<SiteContent> SiteContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed testimonial data using fixed values.
            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial
                {
                    Id = 1,
                    Name = "John Doe",
                    Comment = "Great portfolio!",
                    Rating = 5,
                    SubmittedOn = new DateTime(2025, 1, 20),
                    Approved = true,
                    Featured = true
                },
                new Testimonial
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Comment = "Very professional work.",
                    Rating = 4.5,
                    SubmittedOn = new DateTime(2025, 1, 21),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 3,
                    Name = "Alex Johnson",
                    Comment = "Excellent design!",
                    Rating = 4,
                    SubmittedOn = new DateTime(2025, 1, 22),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 4,
                    Name = "Emily Davis",
                    Comment = "Impressive work.",
                    Rating = 4.5,
                    SubmittedOn = new DateTime(2025, 1, 23),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 5,
                    Name = "Michael Brown",
                    Comment = "Really liked it!",
                    Rating = 5,
                    SubmittedOn = new DateTime(2025, 1, 24),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 6,
                    Name = "Sarah Wilson",
                    Comment = "Could be better.",
                    Rating = 3.5,
                    SubmittedOn = new DateTime(2025, 1, 25),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 7,
                    Name = "David Lee",
                    Comment = "Outstanding effort!",
                    Rating = 5,
                    SubmittedOn = new DateTime(2025, 1, 26),
                    Approved = true,
                    Featured = true
                },
                new Testimonial
                {
                    Id = 8,
                    Name = "Laura Martinez",
                    Comment = "Very creative!",
                    Rating = 4,
                    SubmittedOn = new DateTime(2025, 1, 27),
                    Approved = true,
                    Featured = false
                },
                new Testimonial
                {
                    Id = 9,
                    Name = "Chris Taylor",
                    Comment = "Amazing results!",
                    Rating = 5,
                    SubmittedOn = new DateTime(2025, 1, 28),
                    Approved = true,
                    Featured = true
                },
                new Testimonial
                {
                    Id = 10,
                    Name = "Olivia Harris",
                    Comment = "Satisfying work.",
                    Rating = 4.5,
                    SubmittedOn = new DateTime(2025, 1, 29),
                    Approved = true,
                    Featured = false
                }
            );
        }
    }
}