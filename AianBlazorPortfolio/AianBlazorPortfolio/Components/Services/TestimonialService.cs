using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Models;
using MongoDB.Driver;

namespace AianBlazorPortfolio.Components.Services
{
    public class TestimonialService
    {
        private readonly MongoDbService _mongoService;

        public TestimonialService(MongoDbService mongoService)
        {
            _mongoService = mongoService;
        }

        public async Task<Testimonial> AddTestimonialAsync(Testimonial testimonial)
        {
            testimonial.SubmittedOn = DateTime.UtcNow;
            testimonial.Approved = false;
            await _mongoService.Testimonials.InsertOneAsync(testimonial);
            return testimonial;
        }
    }
}
