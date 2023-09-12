namespace TravelPlanner.Core.Place
{
    public class PlaceInput
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string TimeToSpend { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class PlaceView
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string TimeToSpend { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
