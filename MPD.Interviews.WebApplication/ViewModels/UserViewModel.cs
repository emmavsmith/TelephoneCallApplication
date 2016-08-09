namespace MPD.Interviews.WebApplication.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string FullName => $"{Forename} {Surname}";
    }
}