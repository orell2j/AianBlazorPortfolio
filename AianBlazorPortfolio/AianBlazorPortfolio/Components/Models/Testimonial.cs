namespace AianBlazorPortfolio.Components.Models;

public class Testimonial
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public DateTime SubmittedOn { get; set; }
    public bool Approved { get; set; }
    public bool Featured { get; set; }
    public double Rating { get; set; }
}
