<<<<<<< HEAD
﻿using AutomobileProject.ViewModels.Offer;
=======
﻿using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> f5b16ee745ca8bc92e12e4c5a2194c3b80e6a8a1

namespace AutomobileProject.Services.Offer
{
    public interface IOfferService
    {
        void AddCar(AddCarViewModel addOfferViewModel, string userId);

        void AddMotorcycle(AddMotorcycleViewModel addOfferViewModel, string userId);
<<<<<<< HEAD

        void AddElectricScooter(AddElectricScooterViewModel addOfferViewModel, string userId);
=======
>>>>>>> f5b16ee745ca8bc92e12e4c5a2194c3b80e6a8a1
    }
}
