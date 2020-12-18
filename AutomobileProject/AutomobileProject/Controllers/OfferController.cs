using AutomobileProject.Data.Models;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutomobileProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly ILogger<OfferController> _logger;
        private readonly AutomobileDbContext dbContext;
        private readonly IOfferService offerService;

        public OfferController(ILogger<OfferController> logger, AutomobileDbContext dbContext, IOfferService offerService)
        {
            _logger = logger;
            this.dbContext = new AutomobileDbContext();
            this.offerService = offerService;
        }

        [Authorize]
        public IActionResult AddCar()
        {
            return View(new AddCarViewModel(dbContext));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCar(AddCarViewModel input)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return this.View(new AddCarViewModel(dbContext));
            }

            this.offerService.AddCar(input, userId);
            return this.Redirect("/Cars/AllCars");
        }

        [Authorize]
        public IActionResult AddMotorcycle()
        {
            return View(new AddMotorcycleViewModel(dbContext));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddMotorcycle(AddMotorcycleViewModel offer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return this.View(new AddMotorcycleViewModel(dbContext));
            }

            this.offerService.AddMotorcycle(offer, userId);
            return this.Redirect("/Motorcycles/AllMotorcycles");
        }


        [Authorize]
        public IActionResult AddElectricScooter()
        {
            return View(new AddElectricScooterViewModel(dbContext));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddElectricScooter(AddElectricScooterViewModel offer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return this.View(new AddElectricScooterViewModel(dbContext));
            }

            this.offerService.AddElectricScooter(offer, userId);
            return this.Redirect("/ElectricScooters/AllElectricScooters");
        }
    }
}
