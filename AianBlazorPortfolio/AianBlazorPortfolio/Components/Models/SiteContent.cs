using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Components.Models
{
    public class SiteContent
    {
        [Key]
        public int Id { get; set; } 

        // About Section (multi-language)
        public string? AboutTextEnglish { get; set; }
        public string? AboutTextFrench { get; set; }
        public string? AboutImageUrl { get; set; }

        // Works Section (multi-language)
        public string? WorksContentEnglish { get; set; }
        public string? WorksContentFrench { get; set; }

        // Skills Section (multi-language)
        public string? SkillsContentEnglish { get; set; }
        public string? SkillsContentFrench { get; set; }

        // Contact Section
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }

        // CV Files (store URL paths)
        public string? CVFileFrenchUrl { get; set; }
        public string? CVFileEnglishUrl { get; set; }
    }
}