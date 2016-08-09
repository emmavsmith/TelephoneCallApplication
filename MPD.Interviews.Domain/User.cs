namespace MPD.Interviews.Domain
{
    /// <summary>
    /// A user
    /// </summary>
    public class User
    {
        /// <summary>
        /// The Id of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user's forename
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The user's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The user's position / job title
        /// </summary>
        public string Position { get; set; }
    }
}