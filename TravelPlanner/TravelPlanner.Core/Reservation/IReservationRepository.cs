using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Core.Reservation
{
    internal interface IReservationRepository
    {
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<List<Reservation>> GetAllReservationsAsync(Guid id);
        Task<Guid> CreateFamilyReservationAsync(FamilyReservation familyReservation);
        Task<Guid> CreateFriendsReservationAsync(FriendsReservation friendsReservation);
        Task<Guid> CreateSoloReservationAsync(SoloReservation soloReservation);
        Task<bool> UpdateFamilyReservationAsync(Guid id, FamilyReservation familyReservation);
        Task<bool> UpdateFriendsReservationAsync(Guid id, FriendsReservation friendsReservation);
        Task<bool> UpdateSoloReservationAsync(Guid id, SoloReservation soloReservation);
        Task<bool> DeleteReservationAsync(Guid id);
    }
}
