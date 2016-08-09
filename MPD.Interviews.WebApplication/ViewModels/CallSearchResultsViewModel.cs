using System.Collections.Generic;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallSearchResultsViewModel : CallSearchViewModel
    {
        public IEnumerable<CallDetailViewModel> SearchResults { get; set; }
    }
}