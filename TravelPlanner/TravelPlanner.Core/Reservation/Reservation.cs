using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Core.Reservation
{
    public class Reservation
    {
        public string TicketNumber { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public List<string> Nationalities { get; set; }
        public bool TourGuide { get; set; }
        public List<Languages> TourGuideLanguages { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Transportation Transportation { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Activity.Activity> Activities { get; set; }
        public List<Place.Place> PlacesToVisit { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public ItineraryDetails ItineraryDetails { get; set; }
    }
    public enum Languages
    {
        Arabic,
        English
    }
    public enum ReservationStatus
    {
        Pending, 
        InProgress, 
        Confirmed
    }
}
