namespace TravelPlanner.Core.Accommodation
{
    internal interface IAccommodationRepository
    {
        Task<Accommodation> GetAccommodationByIdAsync(Guid id);
        Task<List<Accommodation>> GetAllAccommodationsAsync();
        Task<List<Accommodation>> GetAccommodationsByFilterAsync(AccommodationFilterCriteria criteria);
        Task<Guid> CreateAccommodationAsync(Accommodation accommodation);
        Task<bool> UpdateAccommodationAsync(Guid id, Accommodation accommodation);
        Task<bool> DeleteAccommodationAsync(Guid id);
        Task<Guid> CreateAccommodationReviewAsync(AccommodationReview review, Guid id, Accommodation accommodation);
        Task<Room> GetAccommodationRoomByIdAsync(Guid id);
        Task<Guid> CreateAccommodationRoomAsync(Room room, Guid accommodationId, Accommodation accommodation);
        Task<bool> UpdateAccommodationRoomAsync(Guid id, Room room, Guid accommodationId, Accommodation accommodation);
        Task<bool> DeleteAccommodationRoomAsync(Guid id, Guid accommodationId, Accommodation accommodation);
    }
}
