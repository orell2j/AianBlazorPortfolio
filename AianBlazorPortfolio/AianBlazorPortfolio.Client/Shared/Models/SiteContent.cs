using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Client.Shared.Models;

public class SiteContent
{
    [Key]
    public int Id { get; set; }  // Always use Id = 1 as the single record

    // About Section
    public string? AboutText { get; set; }
    public string? AboutImageUrl { get; set; }

    // Work Section
    public string? WorksContent { get; set; }

    // Skills Section
    public string? SkillsContent { get; set; }

    // Contact Section
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }

    // CV Files (store URL paths)
    public string? CVFileFrenchUrl { get; set; }
    public string? CVFileEnglishUrl { get; set; }
}

