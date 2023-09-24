using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TravelPlanner.Core.Reservation;

namespace TravelPlanner.Pages.User.Reservation;

public class ReservationFormModel : PageModel
{
    public string PageType { get; set; } //It doesn't work when I assign the value in OnGet and want to retrive it in OnPost

    [BindProperty]
    public FriendsReservation? friendsReservation { get; set; }

    [BindProperty]
    public FamilyReservation? FamilyReservation { get; set; }

    [BindProperty]
    public SoloReservation? SoloReservation { get; set; }

    //private readonly EdgeDBClient _client;
    //public ReservationFormModel(EdgeDBClient client)
    //{
    //    _client = client;
    //}

    public void OnGet()
    {
        var formSession = HttpContext.Session.GetString("_SessionKey");
        PageType = RouteData.Values["TripType"].ToString();
        if (!string.IsNullOrEmpty(formSession))
        {
            if (PageType == "Friends")
            {
                friendsReservation = JsonSerializer.Deserialize<FriendsReservation>(formSession);
            }
            else if (PageType == "Family")
            {
                FamilyReservation = JsonSerializer.Deserialize<FamilyReservation>(formSession);
            }
            else if (PageType == "Solo")
            {
                SoloReservation = JsonSerializer.Deserialize<SoloReservation>(formSession);
            }

        }
    }

    public IActionResult OnPostSubmit()
    {
        PageType = RouteData.Values["TripType"].ToString();
        if (PageType == "Friends")
        {
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

            var result = JsonSerializer.Serialize(friendsReservation);
            HttpContext.Session.SetString("_SessionKey", result);

            return RedirectToPage("/User/Reservation/TransportationForm", new { TripType = "Friends" });
        }
        else if (PageType == "Family")
        {
            FamilyReservation.NumberOfAdults = int.Parse(Request.Form["FamilyAdults"]);
            FamilyReservation.NumberOfChildren = int.Parse(Request.Form["FamilyChildren"]);
            FamilyReservation.Nationalities = Request.Form["FamilyNationalities"];
            FamilyReservation.TourGuide = bool.Parse(Request.Form["FamilyTourGuide"]);
            var langRes = Enum.TryParse(Request.Form["FamilyTourGuideLanguage"], out Languages language);
            if (langRes == true)
            {
                FamilyReservation.TourGuideLanguage = language;
            }
            else if (langRes == false)
            {
                FamilyReservation.TourGuideLanguage = Languages.None;
            }
            FamilyReservation.StartDate = DateTime.Parse(Request.Form["FamilyStartDate"]);
            FamilyReservation.EndDate = DateTime.Parse(Request.Form["FamilyEndDate"]);
            var transpRes = Enum.TryParse(Request.Form["FamilySiwaTransportation"], out SiwaTransportation siwaTransportation);
            if (transpRes == true)
            {
                FamilyReservation.SiwaTransportation = siwaTransportation;
            }
            FamilyReservation.Currency = Request.Form["FamilyCurrency"];

            var result = JsonSerializer.Serialize(FamilyReservation);
            HttpContext.Session.SetString("_SessionKey", result);

            return RedirectToPage("/User/Reservation/TransportationForm", new { TripType = "Family" });
        }
        else if (PageType == "Solo")
        {
            SoloReservation.Nationalities = Request.Form["SoloNationalities"];
            SoloReservation.TourGuide = bool.Parse(Request.Form["SoloTourGuide"]);
            var langRes = Enum.TryParse(Request.Form["SoloTourGuideLanguage"], out Languages language);
            if (langRes == true)
            {
                SoloReservation.TourGuideLanguage = language;
            }
            else if (langRes == false)
            {
                SoloReservation.TourGuideLanguage = Languages.None;
            }
            SoloReservation.StartDate = DateTime.Parse(Request.Form["SoloStartDate"]);
            SoloReservation.EndDate = DateTime.Parse(Request.Form["SoloEndDate"]);
            var transpRes = Enum.TryParse(Request.Form["SoloSiwaTransportation"], out SiwaTransportation siwaTransportation);
            if (transpRes == true)
            {
                SoloReservation.SiwaTransportation = siwaTransportation;
            }
            SoloReservation.JoinGroup = bool.Parse(Request.Form["joinGroup"]);
            SoloReservation.Currency = Request.Form["SoloCurrency"];

            var result = JsonSerializer.Serialize(SoloReservation);
            HttpContext.Session.SetString("_SessionKey", result);


            return RedirectToPage("/User/Reservation/TransportationForm", new { TripType = "Solo" });
        }

        return RedirectToPage("/User/Reservation/TransportationForm");
    }

    public IActionResult OnPostCancel()
    {
        HttpContext.Session.Clear();
        return RedirectToPage("/User/Index");
    }
}

