using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.User;
using AutomobileProject.Services.ElectricScooters;
using AutomobileProject.ViewModels.ElectricScooters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost]
        public IActionResult AllElectricScooters(FiltersInputModel filtersInput)
        {
            var scootersToVisualize = this.electricScootersService.ScootersForVisualization(filtersInput);

            return this.View(scootersToVisualize);
        }

        public IActionResult ScooterDetails(int id)
        {
            var carOffer = this.electricScootersService.GetScooterById(id);
            return this.View(carOffer);
        }

        [Authorize]
        public IActionResult ScooterEditDetails(int id)
        {
            var userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            var scooterOffer = this.electricScootersService.GetScooterById(id);

            if (scooterOffer.UserDetails.EmailAddress == userEmailAddress)
            {
                return this.View(scooterOffer);
            }

            return this.Redirect($"/ElectricScooters/ScooterDetails?id={id}");
        }

        [Authorize]
        [HttpPost]
        public IActionResult ScooterEditDetails(int id, VisualizeScooterDetailsViewModel scooterDetails)
        {
            this.electricScootersService.ChangeScooterDetails(scooterDetails);
            return Redirect($"/ElectricScooters/ScooterDetails?id={id}");
        }

        public IActionResult UserElectricScooters(string sortingType)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedUserScootersToVisualize = this.electricScootersService.GetOnlyUserScooters(userId, sortingType);
                return this.View(sortedUserScootersToVisualize);
            }

            var userScootersToVisualize = this.electricScootersService.GetOnlyUserScooters(userId);
            return this.View(userScootersToVisualize);
        }

        [HttpPost]
        public IActionResult UserElectricScooters(FiltersInputModel filtersInput)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var scootersToVisualize = this.electricScootersService.GetOnlyUserScooters(userId, filtersInput);

            return this.View(scootersToVisualize);
        }


        public IActionResult DeleteScooter(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            //Get scooterOffer to check if the offer was created by the same user doing the delete request.
            var scooterOffer = this.electricScootersService.GetScooterOfferById(id);
        
            if (scooterOffer.UserId == userId)
            {
                this.electricScootersService.DeleteScooterOffer(scooterOffer);
            }
        
            return this.RedirectToAction("UserElectricScooters");
        }
    }
}
