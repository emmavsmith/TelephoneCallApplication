using System.Collections.Generic;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        IEnumerable<UserViewModel> GetAllUsers();
    }
}