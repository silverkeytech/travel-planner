namespace TravelPlanner.Core.Program
{
    public class ProgramView
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ProgramHighlights { get; set; }
        public List<ActivityDetailsView> Activities { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class ProgramInput
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ProgramHighlights { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class ActivityDetailsView
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string TimeToSpend { get; set; }
        public float Price { get; set; }
    }
    public class ActivityDetailsInput
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string TimeToSpend { get; set; }
        public float Price { get; set; }
    }
}
