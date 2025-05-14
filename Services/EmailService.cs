using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Scriban;

namespace App.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;

        public EmailService(IConfiguration config)
        {
            var smtp = config.GetSection("EmailSettings");
            _smtpServer = smtp["SmtpServer"]!;
            _smtpPort = int.Parse(smtp["SmtpPort"]!);
            _smtpUser = smtp["SmtpUser"]!;
            _smtpPassword = smtp["SmtpPassword"]!;
        }


        public async Task SendEmailAsync(string nameFile, string toEmail, string subject, object content)
        {
            // Đọc file template HTML
            var templatePath = Path.Combine(AppContext.BaseDirectory, "Views", "Emails", nameFile);
            var templateContent = await File.ReadAllTextAsync(templatePath);

            // Sử dụng Scriban để render HTML
            var template = Template.Parse(templateContent);
            var renderedHtml = template.Render(content);

            // Tạo email message
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Your App", _smtpUser));
            emailMessage.To.Add(new MailboxAddress("user", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = renderedHtml };

            // Gửi email qua SMTP
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }

}