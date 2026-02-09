using CoffeeAPI.Controllers;
using CoffeeAPI.Models;
using CoffeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace CoffeeAPITests.Controller
{
    public class BrewedCofeeControllerTests
    {
        private Mock<IBrewedCoffeeService> _mockService;
        private BrewedCoffeeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IBrewedCoffeeService>();
            _controller = new BrewedCoffeeController(_mockService.Object);
        }

        [Test]
        public void Get_WhenNotMayFirstAndCounterBelowFive_ReturnsOk()
        {
            var info = new BrewedCoffee
            {
                Message = "Your piping hot coffee is ready",
                Prepared = new DateTime(2026, 02, 10)
            };

            _mockService.Setup(s => s.GetInfo())
                        .Returns(info);

            var result = _controller.Get();

            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(info));
        }

        [Test]
        public void Get_WhenDateIsMayFirst_Returns418()
        {
            var info = new BrewedCoffee
            {
                Message = "April Fools!",
                Prepared = new DateTime(2026, 05, 01)
            };

            _mockService.Setup(s => s.GetInfo())
                        .Returns(info);

            var result = _controller.Get();

            var jsonResult = result as JsonResult;
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(jsonResult.Value, Is.EqualTo(418));
        }

        [Test]
        public void Get_OnFifthRequest_Returns503()
        {
            ResetCounter();

            var info = new BrewedCoffee
            {
                Message = "Coffee",
                Prepared = new DateTime(2026, 02, 10)
            };

            _mockService.Setup(s => s.GetInfo())
                        .Returns(info);

            IActionResult? result = null;

            for (int i = 0; i < 5; i++)
            {
                result = _controller.Get();
            }

            var jsonResult = result as JsonResult;
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(jsonResult.Value, Is.EqualTo(HttpStatusCode.ServiceUnavailable));
        }


        private void ResetCounter()
        {
            var field = typeof(BrewedCoffeeController)
                .GetField("_counter", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            field?.SetValue(null, 0);
        }


    }
}
