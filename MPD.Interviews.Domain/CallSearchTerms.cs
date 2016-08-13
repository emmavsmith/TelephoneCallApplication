using System;

namespace MPD.Interviews.Domain
{
    public class CallSearchTerms
    {
        public CallSearchTerms(int? userId, string customLabel, DateTime? startDate, DateTime? endDate, string phoneNumber)
        {
            UserId = userId;
            CustomLabel = customLabel;
            StartDate = startDate;
            EndDate = endDate;
            PhoneNumber = phoneNumber;
        }

        public int? UserId { get; set; }
        public string CustomLabel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}