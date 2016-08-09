using System.Collections.Generic;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class GroupedCallDetailsViewModel
    {
        public GroupedCallDetailsViewModel()
        {
            CallDetails = new List<CallDetailViewModel>();
        }

        public IList<CallDetailViewModel> CallDetails { get; set; }
        public bool ThresholdExceeded { get; set; }
    }
}