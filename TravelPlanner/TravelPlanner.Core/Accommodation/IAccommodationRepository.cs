namespace TravelPlanner.Core.Accommodation
{
    public interface IAccommodationRepository
    {
        Task<AccommodationView> GetAccommodationByIdAsync(Guid id);
        Task<List<AccommodationView>> GetAllAccommodationsAsync();
        //Task<List<AccommodationView>> GetAccommodationsByFilterAsync(AccommodationFilterCriteria criteria);
        Task<Guid> CreateAccommodationAsync(AccommodationInput accommodation);
        Task<bool> UpdateAccommodationAsync(Guid id, AccommodationInput accommodation);
        Task<bool> DeleteAccommodationAsync(Guid id);
        Task CreateAccommodationReviewAsync(AccommodationReviewInput review, Guid accommodationId);
        Task CreateAccommodationRoomsAsync(List<RoomInput> rooms, Guid accommodationId);        
        Task UpdateAccommodationRoomAsync(Guid roomId, RoomInput room);
        Task<bool> DeleteAccommodationRoomAsync(Guid roomId);
    }
}
