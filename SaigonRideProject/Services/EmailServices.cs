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
            var password = _configuration["EmailSettings:AppPassword"]?.Replace(" ", "");
            var host = "smtp.gmail.com";
            var port = 587;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SaigonRide Support", email));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "SaigonRide OTP Code";
            message.Body = new TextPart("html")
            {
                Text = $@"<p>Your OTP code is:</p><h1>{otpCode}</h1>"
            };

            using var client = new SmtpClient();
            try
            {
                client.Timeout = 15000;
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(email, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.WriteLine("Gmail sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GMAIL SMTP ERROR: {ex.Message}");
            }
        }
    }
}