using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace SaigonRideProject.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendOtpEmail(string toEmail, string otpCode)
        {
            var email = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:AppPassword"];
            var host = _configuration["EmailSettings:Host"] ?? "smtp.gmail.com";
            var port = int.Parse(_configuration["EmailSettings:Port"] ?? "587");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SaigonRide", email));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "SaigonRide OTP";
            message.Body = new TextPart("plain") { Text = $"Your OTP code is: {otpCode}" };

            using var client = new SmtpClient();
            try
            {
                client.Timeout = 10000;
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(email, password.Replace(" ", ""));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SMTP ERROR: {ex.Message}");
            }
        }
    }
}