using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Core.Reservation
{
    public class ItineraryDetails
    {
        public int NumberOfDays { get; set; }
        public List<DayProgram> DaysPrograms { get; set; }
        public TourGuide AssignedTourGuide { get; set; }

    }
    public class DayProgram
    {
        public int DayNumber { get; set; }
        public List<DaySection> Sections { get; set; }
    }
    public class DaySection
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
