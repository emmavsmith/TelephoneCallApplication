using System.Collections.Generic;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Services.Interfaces
{
    public interface ICallDetailsService
    {
        bool AddCallDetailRecord(CallDetailViewModel model);
        IList<CallDetailViewModel> GetAllCalls();

        IList<CallDetailViewModel> GetCallsBySearch(CallSearchTermsViewModel searchTerms);
    }
}