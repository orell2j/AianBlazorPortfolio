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

            // default testimonials values
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

            // my CV information in the portfolio
            modelBuilder.Entity<SiteContent>().HasData(
                new SiteContent 
                { 
                    Id = 1,
                    // About Section: extracted from the CVs
                    AboutTextEnglish = "Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.",
                    AboutTextFrench = "Étudiant passionné d'informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d'applications web full-stack. À la recherche d'un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.",
            
                    // Works Section: list of projects (from the CVs)
                    WorksContentEnglish = "<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>",
                    WorksContentFrench = "<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>",
            
                    // Skills Section: list of technical and soft skills
                    SkillsContentEnglish = "<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>",
                    SkillsContentFrench = "<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d'équipe, Résolution de problèmes</p>",
            
                    // Contact Section: contact info from the CV
                    ContactEmail = "aianbat50@gmail.com",
                    ContactPhone = "+1 (438) 528-3019",
                    GithubUrl = "https://github.com/orell2j",
                    LinkedInUrl = "http://www.linkedin.com/in/aian-batoochirov-50521318b",
            
                    // Also, set the default CV file paths if needed
                    CVFileEnglishUrl = "/files/CV Aian Batoochirov EN.pdf",
                    CVFileFrenchUrl = "/files/CV Aian Batoochirov FR.pdf"
                }
            );
        }
    }
}