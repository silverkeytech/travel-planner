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
    private string PageType { get; set; }

    [BindProperty]
    public Core.Reservation.Reservation? newReservation { get; set; }

    private readonly EdgeDBClient _client;
    public ReservationFormModel(EdgeDBClient client)
    {
        _client = client;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
        PageType = RouteData.Values["TripType"]?.ToString();

        if (PageType == "Friends")
        {
            FriendsReservation friendsReservation = (FriendsReservation)newReservation;
            HttpContext.Session.SetInt32(SessionKeyNAdults, friendsReservation.NumberOfAdults);
            HttpContext.Session.SetString(SessionKeyNationalities, friendsReservation.Nationalities);
            HttpContext.Session.SetString(SessionKeyTourGuide, friendsReservation.TourGuide.ToString());
            HttpContext.Session.SetString(SessionKeyLanguages, friendsReservation.TourGuideLanguage.ToString());
            HttpContext.Session.SetString(SessionKeyStartDate, friendsReservation.StartDate.ToString());
            HttpContext.Session.SetString(SessionKeyEndDate, friendsReservation.EndDate.ToString());
            HttpContext.Session.SetString(SessionKeySiwaTransportation, friendsReservation.Transportation.ToString());
            HttpContext.Session.SetString(SessionKeyCurrency, friendsReservation.Currency);
        }
        else if (PageType == "Family")
        {
            FamilyReservation familyReservation = (FamilyReservation)newReservation;
            HttpContext.Session.SetInt32(SessionKeyNAdults, familyReservation.NumberOfAdults);
            HttpContext.Session.SetInt32(SessionKeyNChildren, familyReservation.NumberOfChildren);
            HttpContext.Session.SetString(SessionKeyNationalities, familyReservation.Nationalities);
            HttpContext.Session.SetString(SessionKeyTourGuide, familyReservation.TourGuide.ToString());
            HttpContext.Session.SetString(SessionKeyLanguages, familyReservation.TourGuideLanguage.ToString());
            HttpContext.Session.SetString(SessionKeyStartDate, familyReservation.StartDate.ToString());
            HttpContext.Session.SetString(SessionKeyEndDate, familyReservation.EndDate.ToString());
            HttpContext.Session.SetString(SessionKeySiwaTransportation, familyReservation.Transportation.ToString());
            HttpContext.Session.SetString(SessionKeyCurrency, familyReservation.Currency);
        }
        else if (PageType == "Solo")
        {
            SoloReservation soloReservation = (SoloReservation)newReservation;
            HttpContext.Session.SetString(SessionKeyNationalities, soloReservation.Nationalities);
            HttpContext.Session.SetString(SessionKeyTourGuide, soloReservation.TourGuide.ToString());
            HttpContext.Session.SetString(SessionKeyLanguages, soloReservation.TourGuideLanguage.ToString());
            HttpContext.Session.SetString(SessionKeyStartDate, soloReservation.StartDate.ToString());
            HttpContext.Session.SetString(SessionKeyEndDate, soloReservation.EndDate.ToString());
            HttpContext.Session.SetString(SessionKeySiwaTransportation, soloReservation.Transportation.ToString());
            HttpContext.Session.SetString(SessionKeyCurrency, soloReservation.Currency);
            HttpContext.Session.SetString(SessionKeyJoinGroup, soloReservation.JoinGroup.ToString());
        }

        return RedirectToPage();
    }
}
