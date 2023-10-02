using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Reservation;
using TravelPlanner.Core.MailKit;
using System.Net.Mail;

namespace TravelPlanner.Pages.User.Reservation
{
    public class ConfirmReservationModel : PageModel
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmailSender _emailSender;
        public string? TicketNumber { get; set; }
        public string? Code { get; set; }
        public ConfirmReservationModel(IEmailSender emailSender, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _emailSender = emailSender;
        }
        public async Task OnGet()
        {
            // TODO: Add the reservation to the database
            //var reservationId = _reservationRepository.CreateFamilyReservationAsync();

            // Add sending email in if reservationId != null
            // else display a message that says failed to create a reservation

            // Send Email
            TicketNumber = GenerateTicketNumber();
            Code = GenerateRandomCode();
            EmailModel emailModel = new EmailModel
            {
                To = "rofaydabassem@gmail.com",
                Subject = "Plan Your Trip With Siwawi",
                Body = _emailSender.CreateEmailBody(TicketNumber, Code)
            };
            await _emailSender.SendEmailAsync(emailModel);
        }
        private string GenerateTicketNumber()
        {
            // TODO: Implement Ticket number generator
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private string GenerateRandomCode()
        {
            // TODO: Implement your logic to generate a random code
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
    }
}
