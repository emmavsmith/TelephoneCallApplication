using System;
using System.ComponentModel.DataAnnotations;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallSearchTermsViewModel
    {
        public int? UserId { get; set; }
        public string CustomLabel { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}