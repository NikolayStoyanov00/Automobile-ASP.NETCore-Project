using AutomobileProject.Services.Motorcycles;
using AutomobileProject.ViewModels.Motorcycles;
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

        public IActionResult AllMotorcycles()
        {
            var motorcyclesToVisualize = this.motorcyclesService.MotorcyclesForVisualization();

            return this.View(motorcyclesToVisualize);
        }

        [HttpPost]
        public IActionResult AllMotorcycles(FiltersInputModel filtersInput)
        {
            var motorcyclesToVisualize = this.motorcyclesService.MotorcyclesForVisualization(filtersInput);

            return this.View(motorcyclesToVisualize);
        }

        public IActionResult UserMotorcycles()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
