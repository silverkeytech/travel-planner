using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Accommodation;

namespace TravelPlanner.Pages.User.Reservation
{
    public class AccommodationListModel : PageModel
    {
        private readonly IAccommodationRepository _accommodationRepository;
        public List<AccommodationView> AccommodationList { get; set; } = new List<AccommodationView>();
        public AccommodationListModel(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }
        public async Task OnGet()
        {
            AccommodationList = await _accommodationRepository.GetAllAccommodationsAsync();
        }
    }
}
