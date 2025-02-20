using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Models;

namespace AianBlazorPortfolio.Components.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    {
        private readonly MongoDbService _mongoService;

        public TestimonialController(MongoDbService mongoService)
        {
            _mongoService = mongoService;
        }

        // POST: api/testimonial/submit
        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] Testimonial testimonial)
        {
            testimonial.SubmittedOn = DateTime.UtcNow;
            testimonial.Approved = false; // new testimonials are not approved by default
            await _mongoService.Testimonials.InsertOneAsync(testimonial);
            return Ok(testimonial);
        }

        // GET: api/testimonial/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var testimonials = await _mongoService.Testimonials.Find(_ => true).ToListAsync();
            return Ok(testimonials);
        }

        // GET: api/testimonial/list
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Approved, true) &
                         Builders<Testimonial>.Filter.Eq(t => t.Featured, true);
            var testimonials = await _mongoService.Testimonials.Find(filter).ToListAsync();
            return Ok(testimonials);
        }

        // POST: api/testimonial/approve/{id}
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> Approve(string id)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Id, id);
            var update = Builders<Testimonial>.Update.Set(t => t.Approved, true);
            var result = await _mongoService.Testimonials.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
                return NotFound();
            var testimonial = await _mongoService.Testimonials.Find(filter).FirstOrDefaultAsync();
            return Ok(testimonial);
        }

        // POST: api/testimonial/reject/{id}
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> Reject(string id)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Id, id);
            var result = await _mongoService.Testimonials.DeleteOneAsync(filter);
            if (result.DeletedCount == 0)
                return NotFound();
            return Ok(new { message = "Testimonial rejected/removed" });
        }

        // POST: api/testimonial/disapprove/{id}
        [HttpPost("disapprove/{id}")]
        public async Task<IActionResult> Disapprove(string id)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Id, id);
            var update = Builders<Testimonial>.Update.Set(t => t.Approved, false)
                                                     .Set(t => t.Featured, false);
            var result = await _mongoService.Testimonials.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
                return NotFound();
            return Ok(new { message = "Testimonial disapproved" });
        }

        // POST: api/testimonial/feature/{id}?featured=true
        [HttpPost("feature/{id}")]
        public async Task<IActionResult> SetFeatured(string id, [FromQuery] bool featured)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Id, id);
            var testimonial = await _mongoService.Testimonials.Find(filter).FirstOrDefaultAsync();
            if (testimonial == null)
                return NotFound();

            if (featured && !testimonial.Approved)
                return BadRequest("Only approved testimonials can be featured.");

            var update = Builders<Testimonial>.Update.Set(t => t.Featured, featured);
            await _mongoService.Testimonials.UpdateOneAsync(filter, update);
            testimonial.Featured = featured;
            return Ok(testimonial);
        }

        // POST: api/testimonial/update
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Testimonial updatedTestimonial)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.Id, updatedTestimonial.Id);
            var update = Builders<Testimonial>.Update
                .Set(t => t.Name, updatedTestimonial.Name)
                .Set(t => t.Comment, updatedTestimonial.Comment)
                .Set(t => t.Rating, updatedTestimonial.Rating)
                .Set(t => t.Approved, updatedTestimonial.Approved)
                .Set(t => t.Featured, updatedTestimonial.Featured);

            var result = await _mongoService.Testimonials.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
                return NotFound();

            var testimonial = await _mongoService.Testimonials.Find(filter).FirstOrDefaultAsync();
            return Ok(testimonial);
        }
    }
}
