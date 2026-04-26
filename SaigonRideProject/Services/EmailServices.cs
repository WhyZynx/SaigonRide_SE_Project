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

        public void SendOtpEmail(string toEmail, string otpCode)
        {
            var email = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:AppPassword"];
            var host = _configuration["EmailSettings:Host"];
            var portString = _configuration["EmailSettings:Port"];

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(host) ||
                string.IsNullOrEmpty(portString))
            {
                throw new Exception("Email configuration is missing in appsettings.json");
            }

            var port = int.Parse(portString);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("SaigonRide", email));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "SaigonRide OTP";
            message.Body = new TextPart("plain")
            {
                Text = $"Your OTP code is: {otpCode}"
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();

            client.Connect(host, port, MailKit.Security.SecureSocketOptions.StartTls);

            client.Authenticate(email, password);

            client.Send(message);

            client.Disconnect(true);
        }
    }
}