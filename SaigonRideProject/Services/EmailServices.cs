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
            var email = _configuration["EmailSettings:Email"] ?? _configuration["EmailSettings__Email"];
            var password = _configuration["EmailSettings:AppPassword"] ?? _configuration["EmailSettings__AppPassword"];
            var host = _configuration["EmailSettings:Host"] ?? _configuration["EmailSettings__Host"] ?? "smtp.gmail.com";
            var portString = _configuration["EmailSettings:Port"] ?? _configuration["EmailSettings__Port"] ?? "587";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return;

            var port = int.Parse(portString);
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

                client.Connect(host, port, SecureSocketOptions.StartTls);
                client.Authenticate(email, password.Replace(" ", "")); 
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SMTP Error: " + ex.Message);
            }
        }
    }
}