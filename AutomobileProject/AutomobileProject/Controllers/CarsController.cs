using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.User;
using AutomobileProject.Services.Offer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutomobileProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly ILogger<CarsController> _logger;
        private readonly AutomobileDbContext dbContext;
        private readonly ICarsService carsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarsController(ILogger<CarsController> logger, AutomobileDbContext dbContext, ICarsService carsService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.dbContext = new AutomobileDbContext();
            this.carsService = carsService;
            _userManager = userManager;
        }

        public IActionResult All()
        {
            var carsToVisualize = this.carsService.CarsForVisualization();
            return this.View(carsToVisualize);
        }

        public IActionResult CarDetails(int id)
        {
            var carOffer = this.carsService.GetCarById(id);
            return this.View(carOffer);
        }
    }
}