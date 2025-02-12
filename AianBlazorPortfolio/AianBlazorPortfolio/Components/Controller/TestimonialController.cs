using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AianBlazorPortfolio.Components.Models;
using AianBlazorPortfolio.Components.Data;

namespace AianBlazorPortfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    {
        private readonly TestimonialDbContext _context;

        public TestimonialController(TestimonialDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] Testimonial testimonial)
        {
            testimonial.SubmittedOn = DateTime.Now;
            testimonial.Approved = false; // New testimonials need admin approval
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return Ok(testimonial);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            // Return only approved testimonials to the public.
            var approved = await _context.Testimonials.Where(t => t.Approved).ToListAsync();
            return Ok(approved);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            // Return all testimonials (approved and pending)
            var allTestimonials = await _context.Testimonials.ToListAsync();
            return Ok(allTestimonials);
        }

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
    }
}
