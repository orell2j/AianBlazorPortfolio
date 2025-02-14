using AianBlazorPortfolio.Components.Data;
using AianBlazorPortfolio.Components.Models; // adjust namespace as needed
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AianBlazorPortfolio.Components.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly TestimonialDbContext _dbContext;

        public ContentController(TestimonialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/content
        [HttpGet]
        public async Task<ActionResult<SiteContent>> GetContent()
        {
            // Assuming there's only one SiteContent record (Id = 1)
            var content = await _dbContext.SiteContents.FirstOrDefaultAsync();
            if (content == null)
            {
                return NotFound();
            }
            return content;
        }

        // POST api/content/update
        [HttpPost("update")]
        public async Task<IActionResult> UpdateContent([FromBody] SiteContent updatedContent)
        {
            if (updatedContent == null)
            {
                return BadRequest();
            }

            // Retrieve the existing content record (assuming a single record with Id=1)
            var content = await _dbContext.SiteContents.FirstOrDefaultAsync();
            if (content == null)
            {
                // Optionally, create a new record if none exists.
                _dbContext.SiteContents.Add(updatedContent);
            }
            else
            {
                // Update properties
                content.AboutText = updatedContent.AboutText;
                content.AboutImageUrl = updatedContent.AboutImageUrl;
                content.WorksContent = updatedContent.WorksContent;
                content.SkillsContent = updatedContent.SkillsContent;
                content.ContactEmail = updatedContent.ContactEmail;
                content.ContactPhone = updatedContent.ContactPhone;
                content.CVFileFrenchUrl = updatedContent.CVFileFrenchUrl;
                content.CVFileEnglishUrl = updatedContent.CVFileEnglishUrl;
            }

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}