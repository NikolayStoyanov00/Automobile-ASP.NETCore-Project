using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutomobileProject.Areas.Identity.Pages;
using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.User;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult AllCars(string sortingType)
        {
            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedCarsToVisualize = this.carsService.CarsForVisualization(sortingType);
                return this.View(sortedCarsToVisualize);
            }

            var carsToVisualize = this.carsService.CarsForVisualization();
            return this.View(carsToVisualize);
        }

        [HttpPost]
        public IActionResult AllCars(FiltersInputModel filtersInput)
        {
            var carsToVisualize = this.carsService.CarsForVisualization(filtersInput);
            return this.View(carsToVisualize);
        }

        public IActionResult CarDetails(int id)
        {
            var carOffer = this.carsService.GetCarById(id);
            return this.View(carOffer);
        }

        [Authorize]
        public IActionResult CarEditDetails(int id)
        {
            var userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            var carOffer = this.carsService.GetCarById(id);

            if (carOffer.UserDetails.EmailAddress == userEmailAddress)
            {
                return this.View(carOffer);
            }

            return this.Redirect($"/Cars/CarDetails?id={id}");
        }

        [Authorize]
        [HttpPost]
        public IActionResult CarEditDetails(int id, VisualizeCarDetailsViewModel carDetails)
        {
            this.carsService.ChangeCarDetails(carDetails);
            return Redirect($"/Cars/CarDetails?id={id}");
        }

        public IActionResult UserCars(string sortingType)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedUserCarsToVisualize = this.carsService.GetOnlyUserCars(userId, sortingType);
                return this.View(sortedUserCarsToVisualize);
            }

            var userCarsToVisualize = this.carsService.GetOnlyUserCars(userId);
            return this.View(userCarsToVisualize);
        }

        [HttpPost]
        public IActionResult UserCars(FiltersInputModel filtersInput)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carsToVisualize = this.carsService.GetOnlyUserCars(userId, filtersInput);

            return this.View(carsToVisualize);
        }


        public IActionResult DeleteCar(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Get carOffer to check if the offer was created by the same user doing the delete request
            var carOffer = this.carsService.GetCarOfferById(id);

            if (carOffer.UserId == userId)
            {
                this.carsService.DeleteCarOffer(carOffer);
            }

            return this.RedirectToAction("UserCars");
        }
    }
}