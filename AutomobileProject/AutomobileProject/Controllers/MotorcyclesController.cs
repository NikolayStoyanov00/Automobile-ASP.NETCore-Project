using AutomobileProject.Services.Motorcycles;
using AutomobileProject.ViewModels.Motorcycles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutomobileProject.Controllers
{
    public class MotorcyclesController : Controller
    {
        private readonly IMotorcyclesService motorcyclesService;

        public MotorcyclesController(IMotorcyclesService motorcyclesService)
        {
            this.motorcyclesService = motorcyclesService;
        }

        public IActionResult AllMotorcycles(string sortingType)
        {
            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedMotorcyclesToVisualize = this.motorcyclesService.MotorcyclesForVisualization(sortingType);
                return this.View(sortedMotorcyclesToVisualize);
            }

            var motorcyclesToVisualize = this.motorcyclesService.MotorcyclesForVisualization();

            return this.View(motorcyclesToVisualize);
        }

        [HttpPost]
        public IActionResult AllMotorcycles(FiltersInputModel filtersInput)
        {
            var motorcyclesToVisualize = this.motorcyclesService.MotorcyclesForVisualization(filtersInput);

            return this.View(motorcyclesToVisualize);
        }

        public IActionResult UserMotorcycles(string sortingType)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(sortingType))
            {
                var sortedUserMotorcyclesToVisualize = this.motorcyclesService.GetOnlyUserMotorcycles(userId, sortingType);
                return this.View(sortedUserMotorcyclesToVisualize);
            }

            var userCarsToVisualize = this.motorcyclesService.GetOnlyUserMotorcycles(userId);

            return this.View(userCarsToVisualize);
        }

        [HttpPost]
        public IActionResult UserMotorcycles(FiltersInputModel filtersInput)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var motorcyclesToVisualize = this.motorcyclesService.GetOnlyUserMotorcycles(userId, filtersInput);

            return this.View(motorcyclesToVisualize);
        }

        public IActionResult MotorcycleDetails(int id)
        {
            var motorcycleOffer = this.motorcyclesService.GetMotorcycleById(id);

            return this.View(motorcycleOffer);
        }

        [Authorize]
        public IActionResult MotorcycleEditDetails(int id)
        {
            var userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            var motorcycleOffer = this.motorcyclesService.GetMotorcycleById(id);

            if (motorcycleOffer.UserDetails.EmailAddress == userEmailAddress)
            {
                return this.View(motorcycleOffer);
            }

            return this.Redirect($"/Motorcycles/MotorcycleDetails?id={id}");
        }

        [Authorize]
        [HttpPost]
        public IActionResult MotorcycleEditDetails(int id, VisualizeMotorcycleDetailsViewModel motorcycleDetails)
        {
            this.motorcyclesService.ChangeMotorcycleDetails(motorcycleDetails);
            return Redirect($"/Motorcycles/MotorcycleDetails?id={id}");
        }

        [Authorize]
        public IActionResult DeleteMotorcycle(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var motorcycleOffer = this.motorcyclesService.GetMotorcycleOfferById(id);

            if (motorcycleOffer.UserId == userId)
            {
                this.motorcyclesService.DeleteMotorcycleOffer(motorcycleOffer);
            }

            return this.RedirectToAction("UserMotorcycles");
        }
    }
}
