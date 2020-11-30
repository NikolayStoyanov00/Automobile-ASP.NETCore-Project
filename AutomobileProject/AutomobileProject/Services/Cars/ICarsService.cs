﻿using AutomobileProject.Data.Models;
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
        ICollection<VisualizeCarViewModel> CarsForFeaturing();


        VisualizeCarDetailsViewModel GetCarById(int id);

        ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId);

        CarOffer GetCarOfferById(int offerId);

        void DeleteCarOffer(CarOffer carOffer);
    }
}
