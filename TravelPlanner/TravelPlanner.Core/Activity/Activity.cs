namespace TravelPlanner.Core.Activity
{
    public class Activity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ProgramHighlights { get; set; }
        public List<ActivityProgramDetails> Programs { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class ActivityProgramDetails
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string TimeToSpend { get; set; }
        public float Price { get; set; }
    }
}
