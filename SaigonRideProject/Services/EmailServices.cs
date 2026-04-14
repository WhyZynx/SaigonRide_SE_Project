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
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                "SaigonRide",
                _configuration["EmailSettings:Email"]!
            ));

            message.To.Add(new MailboxAddress("", toEmail));

            message.Subject = "SaigonRide OTP Verification";

            message.Body = new TextPart("plain")
            {
                Text = $"Your OTP code is: {otpCode}"
            };

            using var client = new SmtpClient();

            client.Connect(
                _configuration["EmailSettings:Host"],
                int.Parse(_configuration["EmailSettings:Port"]!),
                SecureSocketOptions.StartTls
            );

            client.Authenticate(
                _configuration["EmailSettings:Email"],
                _configuration["EmailSettings:AppPassword"]
            );

            client.Send(message);
            client.Disconnect(true);
        }
    }
}