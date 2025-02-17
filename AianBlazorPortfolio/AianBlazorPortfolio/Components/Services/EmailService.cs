using AianBlazorPortfolio.Components.Controller;

namespace AianBlazorPortfolio.Components.Services
{
    public class EmailService
    {
        public Task<bool> SendEmailAsync(EmailRequest request)
        {
            return Task.FromResult(true);
        }
    }
}
