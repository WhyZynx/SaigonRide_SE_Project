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
            var host = _configuration["EmailSettings:Host"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("SaigonRide", email));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "SaigonRide OTP";

            message.Body = new TextPart("plain")
            {
                Text = $"Your OTP code is: {otpCode}"
            };

            using var client = new SmtpClient();
            try
            {
                client.Timeout = 30000;

                client.CheckCertificateRevocation = false;

                client.Connect(host, port, SecureSocketOptions.SslOnConnect);

                client.Authenticate(email, password.Replace(" ", ""));
                client.Send(message);
                client.Disconnect(true);

                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SMTP ERROR: {ex}");
            }
        }
    }
}