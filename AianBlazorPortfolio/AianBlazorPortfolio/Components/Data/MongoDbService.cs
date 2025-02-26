using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using AianBlazorPortfolio.Components.Models;

namespace AianBlazorPortfolio.Components.Data
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = "mongodb+srv://ayanbat50:FHB32pMxr5mvEnjv@aianportfoliodevcluster.sewqw.mongodb.net/?retryWrites=true&w=majority&appName=AianPortfolioDevCluster";
            var databaseName = configuration["MongoDB:DatabaseName"];
            Console.WriteLine($"Using connection string: {connectionString}");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
            SeedData();
        }

        public IMongoCollection<Testimonial> Testimonials =>
          _database.GetCollection<Testimonial>("Testimonials");

        public IMongoCollection<SiteContent> SiteContents =>
          _database.GetCollection<SiteContent>("SiteContents");

        private void SeedData()
        {
            // Seed Testimonials if the collection is empty
            if (!Testimonials.Find(_ => true).Any())
            {
                var defaultTestimonials = new List<Testimonial>
        {
          new Testimonial
          {
            Name = "John Doe",
            Comment = "Great portfolio!",
            Rating = 5,
            SubmittedOn = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc),
            Approved = true,
            Featured = true
          },
          new Testimonial
          {
            Name = "Jane Smith",
            Comment = "Very professional work.",
            Rating = 4.5,
            SubmittedOn = new DateTime(2025, 1, 21, 0, 0, 0, DateTimeKind.Utc),
            Approved = true,
            Featured = false
          },
          new Testimonial
          {
            Name = "Alex Johnson",
            Comment = "Excellent design!",
            Rating = 4,
            SubmittedOn = new DateTime(2025, 1, 22, 0, 0, 0, DateTimeKind.Utc),
            Approved = true,
            Featured = false
          }
        };
                Testimonials.InsertMany(defaultTestimonials);
            }

            // Seed SiteContent if the collection is empty
            if (!_database.GetCollection<SiteContent>("SiteContents").Find(_ => true).Any())
            {
                var defaultSiteContent = new SiteContent
                {
                    AboutTextEnglish = "Hello! I'm Aian Batoochirov, a passionate Computer Science student at Champlain College. I've worked on several full–stack projects and I'm eager to learn new technologies.",
                    AboutTextFrench = "Bonjour ! Je suis Aian Batoochirov, un étudiant passionné en informatique au Collège Champlain.",
                    AboutImageUrl = "/files/images/default-about.jpg",
                    // Initialize with an empty project list or with sample projects if desired:
                    Projects = new List<Project>
          {
            new Project
            {
              Name = "Sample Project",
              RepoUrl = "https://github.com/sample/repo",
              ImageUrl = "/files/images/sample-project.jpg"
            }
          },
                    SkillsContentEnglish = "<p>Skills:<br>Java, C#, React, MongoDB, ASP.NET Core</p>",
                    SkillsContentFrench = "<p>Compétences:<br>Java, C#, React, MongoDB, ASP.NET Core</p>",
                    ContactEmail = "aianbat50@gmail.com",
                    ContactPhone = "+1 (438) 528-3019",
                    GithubUrl = "https://github.com/orell2j",
                    LinkedInUrl = "http://www.linkedin.com/in/aian-batoochirov-50521318b",
                    CVFileEnglishUrl = "/files/CV Aian Batoochirov EN.pdf",
                    CVFileFrenchUrl = "/files/CV Aian Batoochirov FR.pdf"
                };

                SiteContents.InsertOne(defaultSiteContent);
            }
        }
    }
}
