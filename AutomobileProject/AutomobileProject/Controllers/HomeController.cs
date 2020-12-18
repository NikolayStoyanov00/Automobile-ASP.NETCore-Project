using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutomobileProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarsService carsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICarsService carsService)
        {
            _logger = logger;
            this.carsService = carsService;
        }

        public IActionResult Index()
        {
            var carsToVisualize = this.carsService.CarsForFeaturing();
            return this.View(carsToVisualize);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
