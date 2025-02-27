using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Components.Models
{
    [BsonIgnoreExtraElements]
    public class SiteContent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //About
        public string? AboutTextEnglish { get; set; }
        public string? AboutTextFrench { get; set; }
        public string? AboutImageUrl { get; set; }

        //Projects
        public List<Project> Projects { get; set; } = new List<Project>();

        //Skills
        public List<Skill> Skills { get; set; } = new List<Skill>();

        //Contact
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }

        //CV Files
        public string? CVFileFrenchUrl { get; set; }
        public string? CVFileEnglishUrl { get; set; }
    }

    public class Project
    {
        public string? Name { get; set; }
        public string? RepoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class Skill
    {
        public string? Name { get; set; }
        public string? IconUrl { get; set; }
    }
}