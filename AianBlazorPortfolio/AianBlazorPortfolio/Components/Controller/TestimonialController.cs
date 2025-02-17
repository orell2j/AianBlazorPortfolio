using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AianBlazorPortfolio.Components.Models;
using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Services;

namespace AianBlazorPortfolio.Components.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    {
        private readonly TestimonialDbContext _context;
        private readonly TestimonialService _testimonialService;

        public TestimonialController(TestimonialDbContext context, TestimonialService testimonialService)
        {
            _context = context;
            _testimonialService = testimonialService;
        }

        // POST: api/testimonial/submit
        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] Testimonial testimonial)
        {
            // New testimonials are not approved by default.
            var result = await _testimonialService.AddTestimonialAsync(testimonial);
            return Ok(result);
        }

        // GET: api/testimonial/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var allTestimonials = await _context.Testimonials.ToListAsync();
            return Ok(allTestimonials);
        }

        // GET: api/testimonial/list
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var visible = await _context.Testimonials
                .Where(t => t.Approved && t.Featured)
                .ToListAsync();
            return Ok(visible);
        }

        // POST: api/testimonial/approve/{id}
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null)
                return NotFound();
            t.Approved = true;
            await _context.SaveChangesAsync();
            return Ok(t);
        }

        // POST: api/testimonial/reject/{id}
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null)
                return NotFound();
            _context.Testimonials.Remove(t);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Testimonial rejected/removed" });
        }

        // POST: api/testimonial/disapprove/{id}
        [HttpPost("disapprove/{id}")]
        public async Task<IActionResult> Disapprove(int id)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null)
                return NotFound();

            t.Approved = false;
            t.Featured = false;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Testimonial disapproved" });
        }

        // POST: api/testimonial/feature/{id}?featured=true
        [HttpPost("feature/{id}")]
        public async Task<IActionResult> SetFeatured(int id, [FromQuery] bool featured)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null)
                return NotFound();

            if (featured && !t.Approved)
                return BadRequest("Only approved testimonials can be featured.");

            t.Featured = featured;
            await _context.SaveChangesAsync();
            return Ok(t);
        }

        // POST: api/testimonial/update
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Testimonial updatedTestimonial)
        {
            var t = await _context.Testimonials.FindAsync(updatedTestimonial.Id);
            if (t == null)
                return NotFound();

            t.Name = updatedTestimonial.Name;
            t.Comment = updatedTestimonial.Comment;
            t.Rating = updatedTestimonial.Rating;
            t.Approved = updatedTestimonial.Approved;
            t.Featured = updatedTestimonial.Featured;

            await _context.SaveChangesAsync();
            return Ok(t);
        }
    }
}
