using EdgeDB;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelPlanner.Pages.User.Reservation;

public class ReservationFormModel : PageModel
{
    public const string SessionKeyTourGuide = "_TourGuide";


    private readonly EdgeDBClient _client;

    public ReservationFormModel(EdgeDBClient client)
    {
        _client = client;
    }
    public void OnGet()
    {

    }


}
