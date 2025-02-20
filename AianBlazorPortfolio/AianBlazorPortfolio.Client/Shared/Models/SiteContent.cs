using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Client.Shared.Models
{
    public class SiteContent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AboutTextEnglish { get; set; }
        public string AboutTextFrench { get; set; }
        public string AboutImageUrl { get; set; }
        public string WorksContentEnglish { get; set; }
        public string WorksContentFrench { get; set; }
        public string SkillsContentEnglish { get; set; }
        public string SkillsContentFrench { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string CVFileFrenchUrl { get; set; }
        public string CVFileEnglishUrl { get; set; }
    }
}
