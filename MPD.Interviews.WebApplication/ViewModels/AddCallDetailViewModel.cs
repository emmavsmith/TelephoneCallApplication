using System;
using System.Collections.Generic;

namespace MPD.Interviews.WebApplication.ViewModels
{
    public class AddCallDetailViewModel
    {
        public AddCallDetailViewModel()
        {
            Users = new List<UserViewModel>();
            CallDetails = new CallDetailViewModel() {Date = DateTime.Now };
        }

        public IEnumerable<UserViewModel> Users { get; set; }
        public CallDetailViewModel CallDetails { get; set; } 
    }
}