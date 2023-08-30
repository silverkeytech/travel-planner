namespace TravelPlanner.Core.Accommodation
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public string HotelName { get; set; }
        public List<AccommodationMode> AccommodationModes { get; set; }
        public string Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public String ShortDescription { get; set; }
        public String LongDescription { get; set; }
        public string ProfilePicturePath { get; set; }
        public int NumberOfStars { get; set; }
        public List<AccommodationFacility> AccommodationFacilities { get; set; }
        public List<AccommodationReview> AccommodationReviews { get; set; }
        public List<string> ImagesPath { get; set; }
        public DateTime LastUpdate { get; set; }

    }
    public class AccommodationReview
    {
        public Guid Id { get; set; }
        public string GuestName { get; set; }
        public float Rate { get; set; }
        public string comment { get; set; }
    }
    public class Room
    {
        public Guid Id { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public float PricePerNight { get; set; }
        public string Description { get; set; }
        public int AvailableRoomsCount { get; set; }
    }
    public enum RoomType
    {
        SingleRoom,
        DoubleRoom,
        TripleRoom
    }
    public class AccommodationFilterCriteria
    {
        AccommodationMode Mode;
        // To be extended later for filtering search features
        // For now we only focus on filtering with mode only
    }
    public enum AccommodationMode
    {
        Family,
        Friends,
        Solo
    }
    public enum AccommodationFacility
    {
        // TODO:
        // Add accommodation facilities
    }
}
