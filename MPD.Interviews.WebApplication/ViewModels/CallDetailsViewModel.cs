using System.Collections.Generic;
using MPD.Interviews.WebApplication.ViewModels.Enums;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallDetailsViewModel
    {
        public IList<CallDetailViewModel> CallDetails { get; set; } 
        public CallDetailFilterType AppliedFilterType { get; set; }
    }
}