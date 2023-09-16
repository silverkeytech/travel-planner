using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Place;

namespace TravelPlanner.Pages.User.Reservation
{
    public class PlacesListModel : PageModel
    {
        private readonly IPlaceRepository _placeRepository;
        public List<PlaceView> PlaceList { get; set; } = new List<PlaceView>();
        public PlacesListModel(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task OnGet()
        {
            PlaceList = await _placeRepository.GetAllPlacesAsync();
        }
    }
}
