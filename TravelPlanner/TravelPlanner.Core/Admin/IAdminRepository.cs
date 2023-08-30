namespace TravelPlanner.Core.Admin
{
    internal interface IAdminRepository
    {
        Task<AdminActivity> GetAdminByIdAsync(Guid id);
        Task<List<AdminActivity>> GetAllAdminActivitiesAsync();
        Task<Guid> CreateAdminAsync(Admin admin);
        Task<Guid> CreateAdminActivityAsync(AdminActivity adminActivity, Guid adminId, Admin admin);
        Task<bool> UpdateAdminAsync(Guid id, Admin admin);
        Task<bool> DeleteAdminAsync(Guid id);
    }
}
