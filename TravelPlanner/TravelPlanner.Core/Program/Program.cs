namespace TravelPlanner.Core.Program
{
    public class ProgramView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string profile_picture_path { get; set; }
        public List<string> ImagesPath { get; set; }
        public string Description { get; set; }
        public string ProgramHighlights { get; set; }
        public List<ActivityDetailsView> Activities { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class ProgramInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string profile_picture_path { get; set; }
        public List<string> ImagesPath { get; set; }
        public string Description { get; set; }
        public string ProgramHighlights { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class ActivityDetailsView
    {
        public string Name { get; set; }
        public List<string> Details { get; set; }
        public string TimeToSpend { get; set; }
        public float Price { get; set; }
    }
    public class ActivityDetailsInput
    {
        public string Name { get; set; }
        public List<string> Details { get; set; }
        public string TimeToSpend { get; set; }
        public float Price { get; set; }
    }
}
