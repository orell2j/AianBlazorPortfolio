using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Models;

namespace AianBlazorPortfolio.Components.Services
{
    public class TestimonialService
    {
        private readonly TestimonialDbContext _context;

        public TestimonialService(TestimonialDbContext context)
        {
            _context = context;
        }

        public async Task<Testimonial> AddTestimonialAsync(Testimonial testimonial)
        {
            testimonial.SubmittedOn = DateTime.Now;
            testimonial.Approved = false;
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return testimonial;
        }
    }

}
