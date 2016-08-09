using System.Linq;
using System.Web.Mvc;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;
using MPD.Interviews.WebApplication.ViewModels.Enums;

namespace MPD.Interviews.WebApplication.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly ICallDetailsService _callDetailsService;

        public HomeController(ICallDetailsService callDetailsService)
        {
            _callDetailsService = callDetailsService;
        }

        [Route("{filterType?}")]
        public ActionResult Index(CallDetailFilterType filterType = CallDetailFilterType.None)
        {
            var allCalls = _callDetailsService.GetAllCalls();
            var orderedCalls = allCalls.OrderBy(u => u.UserId).ThenBy(d => d.Date).GroupBy(x => x.UserId);
            
            var viewModel = new CallDetailsViewModel()
            {
                AppliedFilterType = filterType,
                CallDetails = orderedCalls
            };

            return View("~/Views/Home/Index.cshtml", viewModel);
        }
    }
}