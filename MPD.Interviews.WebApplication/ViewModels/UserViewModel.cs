namespace MPD.Interviews.WebApplication.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string forename, string surname, string position)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Position = position;
        }

        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string FullName => $"{Forename} {Surname}";
    }
}