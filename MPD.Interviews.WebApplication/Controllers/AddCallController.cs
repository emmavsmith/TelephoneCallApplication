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
            var viewModel = ApplyUsersToViewModel(new AddCallDetailViewModel());
            return View("~/Views/AddCall/AddCall.cshtml", viewModel);
        }

        [HttpPost]
        [Route("AddCall")]
        public ActionResult AddCall(AddCallDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var modelWithUsers = ApplyUsersToViewModel(model);
                return View("~/Views/AddCall/AddCall.cshtml", modelWithUsers);
            }

            var callAdded = _callDetailsService.AddCallDetailRecord(model.CallDetails);

            if (!callAdded)
            {
                var modelWithUsers = ApplyUsersToViewModel(model);
                return View("~/Views/AddCall/AddCall.cshtml", modelWithUsers);
            }

            return View("~/Views/AddCall/CallAdded.cshtml");
        }

        private AddCallDetailViewModel ApplyUsersToViewModel(AddCallDetailViewModel model)
        {
            model.Users = _userService.GetAllUsers();
            return model;
        }
    }
}