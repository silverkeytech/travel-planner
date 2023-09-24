namespace TravelPlanner.Core.Reservation
{
    public class Reservation
    {
        public string? TicketNumber { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string Nationalities { get; set; }
        public bool TourGuide { get; set; }
        public Languages TourGuideLanguage { get; set; }
        // public List<Languages>? TourGuideLanguages { get; set; }
        public string Currency { get; set; } //Create an enum for currencies available 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Transportation? Transportation { get; set; }
        public SiwaTransportation SiwaTransportation { get; set; }
        public List<ReservedRoom>? ReservedRooms { get; set; }
        public List<Activity.Activity>? Activities { get; set; }
        public List<Place.Place>? PlacesToVisit { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public ItineraryDetails? ItineraryDetails { get; set; }
    }
    public class FamilyReservation : Reservation
    {
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
    }
    public class FriendsReservation : Reservation
    {
        public int NumberOfAdults { get; set; }
    }
    public class SoloReservation : Reservation
    {
        public bool JoinGroup { get; set; }
    }
    public class ReservedRoom
    {
        public Accommodation.Room? Room { get; set; }
        public int Count { get; set; }
    }
    public enum Languages
    {
        Arabic,
        English,
        German,
        Spanish,
        None
    }
    public enum ReservationStatus
    {
        Pending,
        InProgress,
        Confirmed
    }

}
