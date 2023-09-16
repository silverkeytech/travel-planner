using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelPlanner.Core.Program;

namespace TravelPlanner.Pages.User.Reservation
{
    public class ProgramListModel : PageModel
    {
        private readonly IProgramRepository _programRepository;
        public List<ProgramView> ProgramList { get; set; } = new List<ProgramView>();
        public ProgramView ProgramDetails;
        public ProgramListModel(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task OnGet()
        {
            ProgramList = await _programRepository.GetAllProgramsAsync();
        }
        public async Task OnPostDetails(Guid programId)
        {
            ProgramDetails = await _programRepository.GetProgramByIdAsync(programId);
        }
    }
}
