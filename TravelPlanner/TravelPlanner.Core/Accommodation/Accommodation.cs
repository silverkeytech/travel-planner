namespace TravelPlanner.Core.Accommodation
{
    public class AccommodationView
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
        public List<AccommodationReviewView> AccommodationReviews { get; set; }
        public List<string> ImagesPath { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<RoomView> Rooms { get; set; }

    }
    public class AccommodationInput
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
        public List<string> ImagesPath { get; set; }
        public DateTime LastUpdate { get; set; }

    }
    public class AccommodationReviewView
    {
        public Guid Id { get; set; }
        public string GuestName { get; set; }
        public string Nationality { get; set; }
        public float Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }

    public class AccommodationReviewInput
    {
        public Guid Id { get; set; }
        public string GuestName { get; set; }
        public string Nationality { get; set; }
        public float Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
    public class RoomInput
    {
        public Guid Id { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public float PricePerNight { get; set; }
        public string Description { get; set; }
        public int AvailableRoomsCount { get; set; }
    }
    public class RoomView
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
        OutdoorSwimmingPool,
        FreeParking,
        Restaurant,
        SpaAndWellnessCentre,
        PetsAllowed,
        WIFI,
        RoomService,
        BeachFront,
        Breakfast
    }
}
