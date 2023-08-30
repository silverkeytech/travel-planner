namespace TravelPlanner.Core.Reservation
{
    public class TourGuide
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public List<Languages> LanguagesSpoken { get; set; }
        public bool Available { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
