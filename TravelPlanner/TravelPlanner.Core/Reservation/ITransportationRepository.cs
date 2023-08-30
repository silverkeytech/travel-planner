namespace TravelPlanner.Core.Reservation
{
    internal interface ITransportationRepository
    {
        Task<Transportation> GetTransportationByIdAsync(Guid id);
        Task<List<Transportation>> GetTransportationsByTypeAsync(string type);
        Task<Guid> CreateTransportationAsync(Transportation transportation);
        Task<bool> UpdateTransportationAsync(Guid id, Transportation transportation);
        Task<bool> DeleteTransportationAsync(Guid id);
    }
}
