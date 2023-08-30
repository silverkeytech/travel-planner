namespace TravelPlanner.Core.Admin
{
    public class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AdminRole AdminRole { get; set; }
        public List<AdminActivity>? AdminActivities { get; set; }
        public DateTime JoinDate { get; set; }
    }
    public class AdminActivity
    {
        public AdminActivityAction AdminActivityAction { get; set; }
        public Reservation.Reservation? Reservation { get; set; }
        public Place.Place? Place { get; set; }
        public Activity.Activity? Activity { get; set; }
        public Accommodation.Accommodation? Accommodation { get; set; }
        public DateTime Date { get; set; }
    }
    public enum AdminActivityAction
    {
        Added,
        Updated,
        Removed
    }
    public enum AdminRole
    {

    }
}
