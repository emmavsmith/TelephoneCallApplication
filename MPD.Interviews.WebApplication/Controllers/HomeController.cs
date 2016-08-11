using System;
using System.Collections.Generic;
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
            var orderedCalls = allCalls.OrderBy(y => y.UserId).GroupBy(x => new {x.UserId, x.Date.Date}).ToList();
            var callDetailsViewModel = new CallDetailsViewModel();

            foreach (var grouping in orderedCalls)
            {
                var group = (IList<CallDetailViewModel>)grouping;
                var callDurationPerDate = 0;
                foreach (var call in group)
                {
                    callDurationPerDate += call.Duration;
                }

                callDetailsViewModel.CallDetails.Add(new GroupedCallsViewModel(group, callDurationPerDate));
            }

            return View("~/Views/Home/Index.cshtml", callDetailsViewModel);
        }
    }
}