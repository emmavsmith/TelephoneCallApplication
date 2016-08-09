using System;

namespace MPD.Interviews.Domain
{
    /// <summary>
    /// Details of a call
    /// </summary>
    public class CallDetails
    {
        /// <summary>
        /// The Id of the call details record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The dialled phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Any custom label applied to this call
        /// </summary>
        public string CustomLabel { get; set; }

        /// <summary>
        /// The duration of the call in seconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The date and time that the call started
        /// </summary>
        public DateTime Date { get; set; }
    }
}