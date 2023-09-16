using TravelPlanner.Core.Accommodation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace TravelPlanner.Pages.User.Reservation
{
    public class AccommodationDetailsModel : PageModel
    {
        private readonly IAccommodationRepository _accommodationRepository;
        public AccommodationView? Accommodation { get; set; }
        public AccommodationDetailsModel(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            Accommodation = await _accommodationRepository.GetAccommodationByIdAsync(id);
            if (Accommodation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
