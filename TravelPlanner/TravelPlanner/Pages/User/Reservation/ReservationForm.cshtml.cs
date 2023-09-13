using EdgeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Reservation;

namespace TravelPlanner.Pages.User.Reservation;
public class ReservationFormModel : PageModel
{
    public string SessionKeyNAdults = "_nAdults";
    public string SessionKeyNationalities = "_Nationalities";
    public string SessionKeyTourGuide = "_TourGuide";
    public string SessionKeyLanguages = "_Languages";
    public string SessionKeyStartDate = "_StartDate";
    public string SessionKeyEndDate = "_EndDate";
    public string SessionKeySiwaTransportation = "_SiwaTransportation";
    public string SessionKeyCurrency = "_Currency";
    public string SessionKeyNChildren = "_nChildren";
    public string SessionKeyJoinGroup = "_JoinGroup";

    [BindProperty]
    public TravelPlanner.Core.Reservation.Reservation? newReservation { get; set; }

    private readonly EdgeDBClient _client;
    public ReservationFormModel(EdgeDBClient client)
    {
        _client = client;
    }

    public void OnPageHandlerExecuting()
    {
        if (RouteData.Values["TripType"]?.ToString() == "Friends")
        {
            newReservation = new FriendsReservation();
        }
        else if (RouteData.Values["TripType"]?.ToString() == "Family")
        {
            newReservation = new FamilyReservation();
        }
        else if (RouteData.Values["TripType"]?.ToString() == "Solo")
        {
            newReservation = new SoloReservation();
        }
    }

    public async Task<IActionResult> OnPostAddOrEditReservation
    {

    }
}
