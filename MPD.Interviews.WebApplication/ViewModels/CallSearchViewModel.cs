using System.Collections.Generic;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallSearchViewModel
    {
        public CallSearchTermsViewModel SearchTerms { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; } 
    }
}