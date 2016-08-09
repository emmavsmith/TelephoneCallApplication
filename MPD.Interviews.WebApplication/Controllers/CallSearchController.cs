using System.Web.Mvc;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Controllers
{
    [RoutePrefix("Search")]
    public class CallSearchController : Controller
    {
        private readonly ICallDetailsService _callDetailsService;
        private readonly IUserService _userService;

        public CallSearchController(ICallDetailsService callDetailsService, IUserService userService)
        {
            _callDetailsService = callDetailsService;
            _userService = userService;
        }

        [Route("Search")]
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new CallSearchViewModel()
            {
                SearchTerms = new CallSearchTermsViewModel()
            };

            viewModel = ApplyUsersToViewModel(viewModel);

            return View("~/Views/CallSearch/Search.cshtml", viewModel);
        }

        [Route("Search")]
        [HttpPost]
        public ActionResult Search(CallSearchViewModel model)
        {
            var result = _callDetailsService.GetCallsBySearch(model.SearchTerms);

            var searchTerms = ApplyUsersToViewModel(model);

            var resultModel = new CallSearchResultsViewModel()
            {
                SearchResults = result,
                SearchTerms = searchTerms.SearchTerms,
                Users = searchTerms.Users
            };

            return View("~/Views/CallSearch/Results.cshtml", resultModel);
        }

        private CallSearchViewModel ApplyUsersToViewModel(CallSearchViewModel model)
        {
            var users = _userService.GetAllUsers();
            model.Users = users;
            return model;
        }
    }
}