using System;
using System.Collections.Generic;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class GroupedCallsViewModel
    {
        public GroupedCallsViewModel()
        {

        }

        public GroupedCallsViewModel(IList<CallDetailViewModel> callDetails, int groupedCallsDuration)
        {
            CallDetails = callDetails;
            GroupedCallsDuration = groupedCallsDuration;
        }

        public IList<CallDetailViewModel> CallDetails { get; set; }
        public int GroupedCallsDuration { get; set; }
        public decimal DurationInMinutes => Math.Round(GroupedCallsDuration / 60M, 2);
    }
}