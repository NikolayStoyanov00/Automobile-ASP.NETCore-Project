using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Motorcycles;
using System.Collections.Generic;

namespace AutomobileProject.Services.Motorcycles
{
    public interface IMotorcyclesService
    {
        ICollection<VisualizeMotorcycleViewModel> MotorcyclesForVisualization(FiltersInputModel filters);
        ICollection<VisualizeMotorcycleViewModel> MotorcyclesForVisualization();
        VisualizeMotorcycleDetailsViewModel GetMotorcycleById(int id);
        MotorcycleOffer GetMotorcycleOfferById(int offerId);

        ICollection<VisualizeMotorcycleViewModel> GetOnlyUserMotorcycles(string userId);
        ICollection<VisualizeMotorcycleViewModel> GetOnlyUserMotorcycles(string userId, FiltersInputModel filters);
        void DeleteMotorcycleOffer(MotorcycleOffer motorcycleOffer);
    }
}
