namespace TravelPlanner.Core.MailKit
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailModel email);
        string CreateEmailBody(string ticketNumber, string code);
    }
}
