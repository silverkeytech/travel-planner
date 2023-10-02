using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MailKit.Security;
using MimeKit;
namespace TravelPlanner.Core.MailKit
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailModel mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        public string CreateEmailBody(string ticketNumber, string code)
        {
            string body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        /* Add some basic styling to the email content */
                        body {{
                            font-family: Arial, sans-serif;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                        }}
                        .thank-you {{
                            font-size: 18px;
                            font-weight: bold;
                            margin-bottom: 20px;
                        }}
                        .ticket-info {{
                            font-size: 16px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='thank-you'>
                            Thanks for using Siwawi Planner!
                        </div>
                        <div class='ticket-info'>
                            You have recently made your itinerary with us. Here is your ticket number and code:
                            <br/><br/>
                            <strong>Ticket Number:</strong> {ticketNumber}
                            <br/>
                            <strong>Code:</strong> {code}
                        </div>
                    </div>
                </body>
                </html>
            ";
            return body;
        }
    }
}