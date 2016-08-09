using System;
using System.ComponentModel.DataAnnotations;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class CallDetailViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select the user for this call")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a phone number for this call")]
        public string PhoneNumber { get; set; }
        public string CustomLabel { get; set; }

        [Required(ErrorMessage = "Please enter the date and time of this call")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter the duration in seconds for this call")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid positive number for the duration")]
        public int Duration { get; set; }

        public decimal DurationInMinutes => (Duration/60M);
    }
}