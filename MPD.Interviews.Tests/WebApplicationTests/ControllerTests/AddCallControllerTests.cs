﻿using System;
using System.Web.Mvc;
using MPD.Interviews.WebApplication.Controllers;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;

namespace MPD.Interviews.Tests.WebApplicationTests.ControllerTests
{
    [TestFixture]
    public class AddCallControllerTests
    {
        private IUserService _userService;
        private ICallDetailsService _callDetailsService;
        private AddCallController _controller;

        [SetUp]
        public void Setup()
        {
            _userService = MockRepository.GenerateMock<IUserService>();
            _callDetailsService = MockRepository.GenerateMock<ICallDetailsService>();
            _controller = new AddCallController(_userService, _callDetailsService);
        }

        [Test]
        public void WhenAddCall_AndModelStateIsNotValid_ThenModelReturnedToAddCallView()
        {
            // Arrange
            _controller.ModelState.AddModelError("", "test error message");
            var addCallDetailViewModel = new AddCallDetailViewModel();

            // Act
            var result = _controller.AddCall(addCallDetailViewModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("~/Views/AddCall/AddCall.cshtml"));
            Assert.That(viewResult.Model, Is.EqualTo(addCallDetailViewModel));
        }

        [Test]
        public void WhenAddCall_AndModelStateIsValid_AndCallAddedSuccessfully_ThenCallAddedView()
        {
            // Arrange
            var addCallDetailViewModel = GetAddCallDetailViewModel();
            _callDetailsService.Stub(x => x.AddCallDetailRecord(Arg<CallDetailViewModel>.Is.Anything)).Return(true);

            // Act
            var result = _controller.AddCall(addCallDetailViewModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("~/Views/AddCall/CallAdded.cshtml"));
            _callDetailsService.AssertWasCalled(x => x.AddCallDetailRecord(Arg<CallDetailViewModel>
                .Matches(y => y.UserId == addCallDetailViewModel.CallDetails.UserId && 
                y.CustomLabel == addCallDetailViewModel.CallDetails.CustomLabel && 
                y.Date == addCallDetailViewModel.CallDetails.Date && 
                y.Duration == addCallDetailViewModel.CallDetails.Duration && 
                y.PhoneNumber == addCallDetailViewModel.CallDetails.PhoneNumber)));
        }

        [Test]
        public void WhenAddCall_AndModelStateIsValid_AndCallNotAddedSuccessfully_ThenCallAddedView()
        {
            // Arrange
            var addCallDetailViewModel = GetAddCallDetailViewModel();
            _callDetailsService.Stub(x => x.AddCallDetailRecord(Arg<CallDetailViewModel>.Is.Anything)).Return(false);

            // Act
            var result = _controller.AddCall(addCallDetailViewModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("~/Views/AddCall/AddCall.cshtml"));
            Assert.That(viewResult.Model, Is.EqualTo(addCallDetailViewModel));
        }

        private static AddCallDetailViewModel GetAddCallDetailViewModel()
        {
            return new AddCallDetailViewModel()
            {
                CallDetails = new CallDetailViewModel()
                {
                    UserId = 1,
                    CustomLabel = "Test Record",
                    Date = new DateTime(2016, 07, 07),
                    Duration = 1000,
                    PhoneNumber = "01234 567890"
                }
            };
        }
    }
}
