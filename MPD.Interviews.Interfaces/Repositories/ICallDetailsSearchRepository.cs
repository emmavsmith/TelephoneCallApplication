using System.Collections.Generic;
using MPD.Interviews.Domain;

namespace MPD.Interviews.Interfaces.Repositories
{
    public interface ICallDetailsSearchRepository
    {
        IEnumerable<CallDetails> CallDetailsSearch(CallSearchTerms searchTerms);
    }
}