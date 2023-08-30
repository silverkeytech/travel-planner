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
    public enum AdminRole
    {

    }
}
