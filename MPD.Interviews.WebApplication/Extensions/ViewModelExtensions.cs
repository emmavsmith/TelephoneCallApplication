using System.Collections.Generic;
using System.Web.Mvc;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Extensions
{
    public static class ViewModelExtensions
    {
        public static bool IsMobileNumber(this string input)
        {
            return input.StartsWith("07"); //crude, but works for the supplied data
        }

        public static bool IsLandlineNumber(this string input)
        {
            return input.StartsWith("01") && input.Length >= 10 && input.Length <= 14; //again, crude but matches the current data
        }

        public static SelectList ToSelectList(this IEnumerable<UserViewModel> users)
        {
            var userList = new List<UserViewModel>() { null };
            userList.AddRange(users);
            return new SelectList(userList, "Id", "FullName", null);
        }
    }
}