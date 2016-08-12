using System;
using System.Web.Mvc;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Controllers
{
    [RoutePrefix("Calls")]
    public class AddCallController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICallDetailsService _callDetailsService;

        public AddCallController(IUserService userService, ICallDetailsService callDetailsService)
        {
            _userService = userService;
            _callDetailsService = callDetailsService;
        }

        [HttpGet]
        [Route("AddCall")]
        public ActionResult Index()
        {
            var viewModel = new AddCallDetailViewModel()
            {
                Users = _userService.GetAllUsers()
            };

            return View("~/Views/AddCall/AddCall.cshtml", viewModel);
        }

        [HttpPost]
        [Route("AddCall")]
        public ActionResult AddCall(AddCallDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/AddCall/AddCall.cshtml", model);
            }

            var callAdded = _callDetailsService.AddCallDetailRecord(model.CallDetails);

            return !callAdded ? View("~/Views/AddCall/AddCall.cshtml", model) : View("~/Views/AddCall/CallAdded.cshtml");
        }
    }
}