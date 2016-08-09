using System;

namespace MPD.Interviews.Domain
{
    public class CallSearchTerms
    {
        public int? UserId { get; set; }
        public string CustomLabel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}