using AianBlazorPortfolio.Components.Services;
using Microsoft.AspNetCore.Mvc;

namespace AianBlazorPortfolio.Components.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            bool result = await _emailService.SendEmailAsync(request);
            if (result)
                return Ok(new { message = "Email sent" });
            else
                return StatusCode(500, new { message = "Failed to send email" });
        }
    }

    public class EmailRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}
