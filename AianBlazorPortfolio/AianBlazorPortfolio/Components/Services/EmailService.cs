using MailKit.Net.Smtp;
using MimeKit;
using AianBlazorPortfolio.Components.Controller;

namespace AianBlazorPortfolio.Components.Services
{
    public class EmailService
    {
        public async Task<bool> SendEmailAsync(EmailRequest request)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Portfolio Website", "no-reply@yourdomain.com"));

                message.To.Add(MailboxAddress.Parse("aianbat50@gmail.com"));

                message.Subject = $"New Contact Form Message from {request.Name}";

                message.Body = new TextPart("plain")
                {
                    Text = $"Name: {request.Name}\n" +
                           $"Email: {request.Email}\n\n" +
                           $"Message:\n{request.Message}"
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("ayanbat50@gmail.com", "glgr bvyj ufxu riue");
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email send error: {ex.Message}");
                return false;
            }
        }
    }
}
