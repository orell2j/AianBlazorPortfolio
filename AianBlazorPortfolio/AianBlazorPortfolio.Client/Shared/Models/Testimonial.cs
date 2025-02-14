using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Client.Shared.Models;

public class Testimonial
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Comment is required.")]
    public string Comment { get; set; }

    public DateTime SubmittedOn { get; set; }
    public bool Approved { get; set; }
    public bool Featured { get; set; }

    [Range(0.5, 5, ErrorMessage = "Rating must be between 0.5 and 5.")]
    public double Rating { get; set; }
}