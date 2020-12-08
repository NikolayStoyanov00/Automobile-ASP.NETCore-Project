using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Cars;
using AutomobileProject.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Services.Offer
{
    public interface ICarsService
    {
        ICollection<VisualizeCarViewModel> CarsForVisualization(FiltersInputModel filters);
        ICollection<VisualizeCarViewModel> CarsForVisualization();
        ICollection<VisualizeCarViewModel> CarsForVisualization(string sortingType);
        ICollection<VisualizeCarViewModel> CarsForFeaturing();

        VisualizeCarDetailsViewModel GetCarById(int id);

        ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId);
        ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId, string sortingType);
        ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId, FiltersInputModel filters);

        CarOffer GetCarOfferById(int offerId);

        void DeleteCarOffer(CarOffer carOffer);
    }
}
