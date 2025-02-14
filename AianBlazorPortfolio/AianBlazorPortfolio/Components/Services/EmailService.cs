using AianBlazorPortfolio.Components.Controller;

namespace AianBlazorPortfolio.Components.Services
{
    public class EmailService
    {
        public Task<bool> SendEmailAsync(EmailRequest request)
        {
            // Dummy implementation – replace with your actual email sending logic.
            return Task.FromResult(true);
        }
    }
}
