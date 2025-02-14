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
        // Called by regular users to submit a testimonial (which will need admin approval).
        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] Testimonial testimonial)
        {
            // New testimonials are not approved by default.
            var result = await _testimonialService.AddTestimonialAsync(testimonial);
            return Ok(result);
        }

        // GET: api/testimonial/all
        // Admin view: returns all testimonials.
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var allTestimonials = await _context.Testimonials.ToListAsync();
            return Ok(allTestimonials);
        }

        // GET: api/testimonial/list
        // Public view: returns only testimonials that are approved and featured.
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var visible = await _context.Testimonials
                .Where(t => t.Approved && t.Featured)
                .ToListAsync();
            return Ok(visible);
        }

        // POST: api/testimonial/approve/{id}
        // Admin approves a testimonial.
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
        // Admin rejects (deletes) a testimonial.
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


        // POST: api/testimonial/feature/{id}?featured=true
        // Admin marks a testimonial as featured (only allowed if approved).
        [HttpPost("feature/{id}")]
        public async Task<IActionResult> SetFeatured(int id, [FromQuery] bool featured)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null)
                return NotFound();

            // Only allow featuring if the testimonial is approved.
            if (featured && !t.Approved)
                return BadRequest("Only approved testimonials can be featured.");

            t.Featured = featured;
            await _context.SaveChangesAsync();
            return Ok(t);
        }

        // POST: api/testimonial/update
        // Admin updates the testimonial content.
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Testimonial updatedTestimonial)
        {
            var t = await _context.Testimonials.FindAsync(updatedTestimonial.Id);
            if (t == null)
                return NotFound();

            t.Name = updatedTestimonial.Name;
            t.Comment = updatedTestimonial.Comment;
            t.Rating = updatedTestimonial.Rating;
            // Allow admin to update Approved and Featured via this endpoint if desired.
            t.Approved = updatedTestimonial.Approved;
            t.Featured = updatedTestimonial.Featured;

            await _context.SaveChangesAsync();
            return Ok(t);
        }
    }
}
