namespace TravelPlanner.Core.Program
{
    public interface IProgramRepository
    {
        Task<ProgramView> GetProgramByIdAsync(Guid id);
        Task<List<ProgramView>> GetAllProgramsAsync();
        Task<Guid> CreateProgramAsync(ProgramInput program);
        Task<bool> UpdateProgramAsync(Guid id, ProgramInput program);
        Task<bool> DeleteProgramAsync(Guid id);
        Task CreateActivityAsync(List<ActivityDetailsInput> activities, Guid programId);
        Task UpdateActivityAsync(Guid activityId, ActivityDetailsInput activity);
        Task<bool> DeleteActivityAsync(Guid activityId);
    }
}
