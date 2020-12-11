using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.User;
using AutomobileProject.Services.ElectricScooters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileProject.Controllers
{
    public class ElectricScootersController : Controller
    {
        private readonly AutomobileDbContext dbContext;
        private readonly IElectricScootersService electricScootersService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ElectricScootersController(AutomobileDbContext dbContext, IElectricScootersService electricScootersService, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = new AutomobileDbContext();
            this.electricScootersService = electricScootersService;
            _userManager = userManager;
        }

        public IActionResult AllElectricScooters(string sortingType)
        {
            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedCarsToVisualize = this.electricScootersService.ScootersForVisualization(sortingType);
                return this.View(sortedCarsToVisualize);
            }

            var carsToVisualize = this.electricScootersService.ScootersForVisualization();
            return this.View(carsToVisualize);
        }

        //[HttpPost]
        //public IActionResult AllElectricScooters(FiltersInputModel filtersInput)
        //{
        //    var carsToVisualize = this.electricScootersService.CarsForVisualization(filtersInput);

        //    return this.View(carsToVisualize);
        //}

        //public IActionResult CarDetails(int id)
        //{
        //    var carOffer = this.carsService.GetCarById(id);
        //    return this.View(carOffer);
        //}

        //public IActionResult UserCars(string sortingType)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    if (!string.IsNullOrEmpty(sortingType))
        //    {
        //        var sortedUserCarsToVisualize = this.carsService.GetOnlyUserCars(userId, sortingType);
        //        return this.View(sortedUserCarsToVisualize);
        //    }

        //    var userCarsToVisualize = this.carsService.GetOnlyUserCars(userId);
        //    return this.View(userCarsToVisualize);
        //}

        //[HttpPost]
        //public IActionResult UserCars(FiltersInputModel filtersInput)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var carsToVisualize = this.carsService.GetOnlyUserCars(userId, filtersInput);

        //    return this.View(carsToVisualize);
        //}


        //public IActionResult DeleteCar(int id)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    //Get carOffer to check if the offer was created by the same user doing the delete request
        //    var carOffer = this.carsService.GetCarOfferById(id);

        //    if (carOffer.UserId == userId)
        //    {
        //        this.carsService.DeleteCarOffer(carOffer);
        //    }

        //    return this.RedirectToAction("UserCars");
        //}
    }
}
