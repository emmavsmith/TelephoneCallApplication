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
            var callDetailsViewModel = new CallDetailsViewModel(filterType);
            var orderedCallsForFilter = GetOrderedCallsForFilter(filterType, allCalls);

            foreach (var groupsByUser in orderedCallsForFilter)
            {
                foreach (var groupsByUserAndDate in groupsByUser)
                {
                    var group = (IList<CallDetailViewModel>) groupsByUserAndDate;
                    var callDurationPerDate = groupsByUserAndDate.Sum(call => call.Duration);
                    callDetailsViewModel.CallDetails.Add(new GroupedCallsViewModel(group, callDurationPerDate));
                }
            }

          return View("~/Views/Home/Index.cshtml", callDetailsViewModel);
        }

        private static IEnumerable<IEnumerable<IGrouping<DateTime, CallDetailViewModel>>> GetOrderedCallsForFilter(CallDetailFilterType filterType, IList<CallDetailViewModel> allCalls)
        {
            IEnumerable<IEnumerable<IGrouping<DateTime, CallDetailViewModel>>> orderedCalls;

            switch (filterType)
            {
                case CallDetailFilterType.None:

                    orderedCalls = allCalls.OrderBy(x => x.UserId)
                        .GroupBy(y => y.UserId)
                        .Select(group => @group.GroupBy(z => z.Date.Date)).ToList();
                    break;

                case CallDetailFilterType.MorningCalls:

                    orderedCalls = allCalls
                        .Where(c => c.Date.TimeOfDay < new TimeSpan(12, 0, 0))
                        .OrderBy(x => x.UserId)
                        .GroupBy(y => y.UserId)
                        .Select(group => @group.GroupBy(z => z.Date.Date)).ToList();
                    break;

                case CallDetailFilterType.AfternoonCalls:

                    orderedCalls = allCalls
                        .Where(c => c.Date.TimeOfDay > new TimeSpan(12, 0, 0))
                        .OrderBy(x => x.UserId)
                        .GroupBy(y => y.UserId)
                        .Select(group => @group.GroupBy(z => z.Date.Date)).ToList();
                    break;

                case CallDetailFilterType.MobileNumbers:

                    orderedCalls = allCalls
                        .Where(c => c.PhoneNumber.StartsWith("07"))
                        .OrderBy(x => x.UserId)
                        .GroupBy(y => y.UserId)
                        .Select(group => @group.GroupBy(z => z.Date.Date)).ToList();
                    break;

                case CallDetailFilterType.LandlineNumbers:

                    orderedCalls = allCalls
                        .Where(c => !c.PhoneNumber.StartsWith("07"))
                        .OrderBy(x => x.UserId)
                        .GroupBy(y => y.UserId)
                        .Select(group => @group.GroupBy(z => z.Date.Date)).ToList();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterType), filterType, null);
            }

            return orderedCalls;
        }
    }
}