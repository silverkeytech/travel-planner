namespace TravelPlanner.Core.Activity
{
    internal interface IActivityRepository
    {
        Task<Activity> GetActivityByIdAsync(Guid id);
        Task<List<Activity>> GetAllActivitiesAsync();
        Task<Guid> CreateActivityAsync(Activity activity);
        Task<bool> UpdateActivityAsync(Guid id, Activity activity);
        Task<bool> DeleteActivityAsync(Guid id);
    }
}
