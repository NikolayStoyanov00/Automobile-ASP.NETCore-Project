using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.ElectricScooters;
using System.Collections.Generic;

namespace AutomobileProject.Services.ElectricScooters
{
    public interface IElectricScootersService
    {
        ICollection<VisualizeScooterViewModel> ScootersForVisualization();
        ICollection<VisualizeScooterViewModel> ScootersForVisualization(string sortingType);
        ICollection<VisualizeScooterViewModel> ScootersForVisualization(FiltersInputModel filters);

        ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId);
        ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId, string sortingType);
        ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId, FiltersInputModel filters);
        VisualizeScooterDetailsViewModel GetScooterById(int id);

        ElectricScooterOffer GetScooterOfferById(int offerId);
        void DeleteScooterOffer(ElectricScooterOffer scootrOffer);
    }
}
