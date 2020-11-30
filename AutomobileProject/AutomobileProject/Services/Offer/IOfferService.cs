using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Services.Offer
{
    public interface IOfferService
    {
        void AddCar(AddCarViewModel addOfferViewModel, string userId);

        void AddMotorcycle(AddMotorcycleViewModel addOfferViewModel);
    }
}
