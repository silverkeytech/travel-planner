namespace TravelPlanner.Core.Reservation
{
    public class Transportation
    {
        public TransporationType TransporationType { get; set; }
        public int MaxCapacity { get; set; }
        public float Price { get; set; }
    }

    public enum TransporationType
    {
        PrivateSedan,
        PrivateMinibus,
        PublicBus,
        None
    }

    public enum SiwaTransportation
    {
        CarVechile,
        Tuktuk,
        Bicycle
    }
}
