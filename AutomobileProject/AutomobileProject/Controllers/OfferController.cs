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
            //TODO: Add image file validation

            if (!ModelState.IsValid)
            {
                return this.View(new AddCarViewModel(dbContext));
            }

            this.offerService.AddCar(input);
            return this.Redirect("/");
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
            this.offerService.AddMotorcycle(offer);
            return this.Redirect("/");
        }

        public IActionResult Cars()
        {
            var carsToVisualize = this.offerService.CarsForVisualization();
            return this.View(carsToVisualize);
        }

        public IActionResult CarDetails(int id)
        {
            var carOffer = this.offerService.GetCarById(id);
            return this.View(carOffer);
        }
    }
}
