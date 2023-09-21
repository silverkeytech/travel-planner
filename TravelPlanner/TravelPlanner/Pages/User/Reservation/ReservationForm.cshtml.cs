using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Reservation;

namespace TravelPlanner.Pages.User.Reservation;

public class ReservationFormModel : PageModel
{
    //public string SessionKeyNAdults = "_nAdults";
    //public string SessionKeyNationalities = "_Nationalities";
    //public string SessionKeyTourGuide = "_TourGuide";
    //public string SessionKeyLanguages = "_Languages";
    //public string SessionKeyStartDate = "_StartDate";
    //public string SessionKeyEndDate = "_EndDate";
    //public string SessionKeySiwaTransportation = "_SiwaTransportation";
    //public string SessionKeyCurrency = "_Currency";
    //public string SessionKeyNChildren = "_nChildren";
    //public string SessionKeyJoinGroup = "_JoinGroup";
    // private string PageType { get; set; }

    [BindProperty]
    public FriendsReservation friendsReservation { get; set; }


    //private readonly EdgeDBClient _client;
    //public ReservationFormModel(EdgeDBClient client)
    //{
    //    _client = client;
    //}

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        //Languages languages = new Languages();
        //FriendsReservation friendsReservation = new FriendsReservation();
        friendsReservation.NumberOfAdults = int.Parse(Request.Form["NumberOfAdults"]);
        friendsReservation.Nationalities = Request.Form["Nationalities"];
        friendsReservation.TourGuide = bool.Parse(Request.Form["TourGuide"]);
        var langRes = Enum.TryParse(Request.Form["TourGuideLanguage"], out Languages language);
        if (langRes == true)
        {
            friendsReservation.TourGuideLanguage = language;
        }
        else if (langRes == false)
        {
            friendsReservation.TourGuideLanguage = Languages.None;
        }
        friendsReservation.StartDate = DateTime.Parse(Request.Form["StartDate"]);
        friendsReservation.EndDate = DateTime.Parse(Request.Form["EndDate"]);
        var transpRes = Enum.TryParse(Request.Form["siwaTransportation"], out SiwaTransportation siwaTransportation);
        if (transpRes == true)
        {
            friendsReservation.SiwaTransportation = siwaTransportation;
        }
        friendsReservation.Currency = Request.Form["Currency"];

        //PageType = RouteData.Values["TripType"]?.ToString();

        //if (PageType == "Friends")
        //{
        //FriendsReservation friendsReservation = newReservation as FriendsReservation;
        //FriendsReservation friendsReservation = (FriendsReservation)newReservation;
        HttpContext.Session.SetInt32("_nAdults", friendsReservation.NumberOfAdults);
        HttpContext.Session.SetString("_Nationalities", friendsReservation.Nationalities);
        HttpContext.Session.SetString("_TourGuide", friendsReservation.TourGuide.ToString());
        HttpContext.Session.SetString("_TourGuideLanguage", friendsReservation.TourGuideLanguage.ToString());
        HttpContext.Session.SetString("_StartDate", friendsReservation.StartDate.ToString());
        HttpContext.Session.SetString("_EndDate", friendsReservation.EndDate.ToString());
        HttpContext.Session.SetString("_SiwaTransportation", friendsReservation.SiwaTransportation.ToString());
        HttpContext.Session.SetString("_Currency", friendsReservation.Currency);
        //}
        //else if (PageType == "Family")
        //{
        //    FamilyReservation familyReservation = (FamilyReservation)newReservation;
        //    HttpContext.Session.SetInt32(SessionKeyNAdults, familyReservation.NumberOfAdults);
        //    HttpContext.Session.SetInt32(SessionKeyNChildren, familyReservation.NumberOfChildren);
        //    HttpContext.Session.SetString(SessionKeyNationalities, familyReservation.Nationalities);
        //    HttpContext.Session.SetString(SessionKeyTourGuide, familyReservation.TourGuide.ToString());
        //    HttpContext.Session.SetString(SessionKeyLanguages, familyReservation.TourGuideLanguage.ToString());
        //    HttpContext.Session.SetString(SessionKeyStartDate, familyReservation.StartDate.ToString());
        //    HttpContext.Session.SetString(SessionKeyEndDate, familyReservation.EndDate.ToString());
        //    HttpContext.Session.SetString(SessionKeySiwaTransportation, familyReservation.Transportation.ToString());
        //    HttpContext.Session.SetString(SessionKeyCurrency, familyReservation.Currency);
        //}
        //else if (PageType == "Solo")
        //{
        //    SoloReservation soloReservation = (SoloReservation)newReservation;
        //    HttpContext.Session.SetString(SessionKeyNationalities, soloReservation.Nationalities);
        //    HttpContext.Session.SetString(SessionKeyTourGuide, soloReservation.TourGuide.ToString());
        //    HttpContext.Session.SetString(SessionKeyLanguages, soloReservation.TourGuideLanguage.ToString());
        //    HttpContext.Session.SetString(SessionKeyStartDate, soloReservation.StartDate.ToString());
        //    HttpContext.Session.SetString(SessionKeyEndDate, soloReservation.EndDate.ToString());
        //    HttpContext.Session.SetString(SessionKeySiwaTransportation, soloReservation.Transportation.ToString());
        //    HttpContext.Session.SetString(SessionKeyCurrency, soloReservation.Currency);
        //    HttpContext.Session.SetString(SessionKeyJoinGroup, soloReservation.JoinGroup.ToString());
        //}

        return RedirectToPage("/User/Reservation/TransportationForm", new { TripType = "Friends" });
    }
}

//public class FriendsReservation
//{
//    public int NumberOfAdults { get; set; } = 5;
//    public string Nationalities { get; set; } = "";
//}