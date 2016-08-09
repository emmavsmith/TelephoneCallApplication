using System.Collections.Generic;
using System.Linq;
using MPD.Interviews.WebApplication.ViewModels.Enums;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallDetailsViewModel
    {
        public IEnumerable<IGrouping<int, CallDetailViewModel>> CallDetails { get; set; } 
        public CallDetailFilterType AppliedFilterType { get; set; }
    }
}