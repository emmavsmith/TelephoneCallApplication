using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Repositories;

namespace MPD.Interviews.WebApplication.Controllers
{
    [RoutePrefix("seed")]
    public class DataSeedController : Controller
    {
        private readonly IRepository<CallDetails> _callDetailsRepository;
        private readonly Random _rand;

        public DataSeedController(IRepository<CallDetails> callDetailsRepository)
        {
            _callDetailsRepository = callDetailsRepository;
            _rand = new Random();
        }

        /// <summary>
        /// Seed the db with some test data
        /// </summary>
        /// <returns></returns>
        [Route]
        public ActionResult Index()
        {
            var allCalls = _callDetailsRepository.GetAll();
            foreach (var call in allCalls)
            {
                _callDetailsRepository.Delete(call);
            }
            GenerateSeedData();
            return Json(new {ok = true}, JsonRequestBehavior.AllowGet);
        }

        private void GenerateSeedData()
        {
            var calls = new List<CallDetails>();
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                calls.Add(new CallDetails()
                {
                    CustomLabel = $"Record {i.ToString("D2")}",
                    Date = DateTime.Now.AddHours(i),
                    UserId = rand.Next(1,4),
                    PhoneNumber = PhoneNumberFaker(i),
                    Duration = rand.Next(60, 600)
                });
            }

            foreach (var call in calls)
            {
                _callDetailsRepository.Save(call);
            }
        }

        private string PhoneNumberFaker(int seed)
        {
            var mobile = (seed % 2 == 0);
            return mobile 
                ? $"078{seed.ToString("D3")}845{seed.ToString("D3")}"
                : $"01{_rand.Next(1, 9)}1{_rand.Next(500, 800)}{seed.ToString("D3")}";
        }
    }
}