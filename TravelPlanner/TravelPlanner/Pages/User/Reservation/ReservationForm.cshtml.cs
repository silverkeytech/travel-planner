using EdgeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Reservation;

namespace TravelPlanner.Pages.User.Reservation;
public class ReservationFormModel : PageModel
{
    public const string SessionKeyNAdults = "_nAdults";
    public const string SessionKeyNationalities = "_Nationalities";
    public const string SessionKeyTourGuide = "_TourGuide";
    public const string SessionKeyLanguages = "_Languages";
    public const string SessionKeyStartDate = "_StartDate";
    public const string SessionKeyEndDate = "_EndDate";
    public const string SessionKeySiwaTransportation = "_SiwaTransportation";
    public const string SessionKeyCurrency = "_Currency";
    public const string SessionKeyNChildren = "_nChildren";
    public const string SessionKeyJoinGroup = "_JoinGroup";

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


}
