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
                }
            );

            // my CV information in the portfolio
            modelBuilder.Entity<SiteContent>().HasData(
                new SiteContent 
                { 
                    Id = 1,
                    // About Section: extracted from the CVs
                    AboutTextEnglish = "Hello! I'm Aian Batoochirov, <br><br> a passionate Computer Science student at Champlain College. " +
                                        "<br> I've worked on projects full stack webapp projects like a veterinary management system and a billing automation platform. <br>" +
                                        "<br>I'm eager to learn new technologies and am looking for an internship where I can contribute and grow. Let's connect and create something great together!",
                    AboutTextFrench = "Bonjour ! Je suis Aian Batoochirov, <br>" +
                                        "<br>\r\nun étudiant passionné en informatique au Collège Champlain. " +
                                        "<br>\r\nJ'ai travaillé sur des projets full-stack, tels qu'un système de gestion vétérinaire et une plateforme" +
                                        " d'automatisation de la facturation. <br><br>\r\nJe suis avide d'apprendre de nouvelles technologies et je recherche un stage où je pourrais contribuer et évoluer. " +
                                        "Connectons-nous et créons ensemble quelque chose de grand !",
            
                    // Works Section: list of projects (from the CVs)
                    WorksContentEnglish = "<p>\r\n  Projects:" +
                                            "<br>\r\n  • Veterinary Management System – " +
                                            "<a href=\"https://github.com/cgerard321/champlain_petclinic\" target=\"_blank\">GitHub Repo</a>" +
                                            "<br>\r\n  • Billing Automation Platform – " +
                                            "<a href=\"https://github.com/Carlos-123321/CompteExpress\" target=\"_blank\">GitHub Repo</a>\r\n</p>",
                    WorksContentFrench = "<p>\r\n  Projets :" +
                                            "<br>\r\n  • Système de gestion vétérinaire – " +
                                            "<a href=\"https://github.com/cgerard321/champlain_petclinic\" target=\"_blank\">Dépôt GitHub</a>" +
                                            "<br>\r\n  • Plateforme d'automatisation de la facturation – " +
                                            "<a href=\"https://github.com/Carlos-123321/CompteExpress\" target=\"_blank\">Dépôt GitHub</a>\r\n</p>",
            
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