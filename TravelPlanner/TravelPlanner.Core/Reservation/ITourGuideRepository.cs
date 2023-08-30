namespace TravelPlanner.Core.Reservation
{
    internal interface ITourGuideRepository
    {
        Task<TourGuide> GetTourGuideByIdAsync(Guid id);
        Task<List<TourGuide>> GetTourGuidesByLanguageAsync(Languages language);
        Task<List<TourGuide>> GetAllTourGuidesAsync();
        Task<List<Languages>> GetAllLanguagesSpokenByTourGuidesAsync();
        Task<Guid> CreateTourGuideAsync(TourGuide tourGuide);
        Task<bool> UpdateTourGuideAsync(Guid id, TourGuide tourGuide);
        Task<bool> DeleteTourGuideAsync(Guid id);
    }
}
