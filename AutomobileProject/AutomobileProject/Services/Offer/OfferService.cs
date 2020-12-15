using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Offer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Services.Offer
{
    public class OfferService : IOfferService
    {
        private readonly AutomobileDbContext dbContext;

        public OfferService(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCar(AddCarViewModel addCarViewModel, string userId)
        {
            var offer = new CarOffer()
            {
                Title = addCarViewModel.Title,
                Make = addCarViewModel.Make,
                Model = addCarViewModel.Model,
                Year = addCarViewModel.Year,
                Price = addCarViewModel.Price,
                Condition = addCarViewModel.Condition,
                Color = addCarViewModel.Color,
                SteeringWheelSide = addCarViewModel.SteeringWheelSide,
                FuelType = addCarViewModel.FuelType,
                HorsePower = addCarViewModel.HorsePower,
                EngineSize = addCarViewModel.EngineSize,
                Gearbox = addCarViewModel.Gearbox,
                Doors = addCarViewModel.Doors,
                Kilometers = addCarViewModel.Kilometers,
                Description = addCarViewModel.Description,
                ContactNumber = addCarViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow,
            };

            using (var target = new MemoryStream())
            {
                if (addCarViewModel.MainImageFile != null)
                {
                    addCarViewModel.MainImageFile.CopyTo(target);
                    offer.OfferImage = target.ToArray();
                }
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == userId);
            offer.User = user;
            offer.UserId = userId;

            dbContext.CarOffers.Add(offer);
            dbContext.SaveChanges();

            var offerType = "CarOffer";

            if (addCarViewModel.SecondImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.SecondImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.ThirdImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.ThirdImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.FourthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.FourthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.FifthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.FifthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.SixthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.SixthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            dbContext.SaveChanges();
        }


        public void AddMotorcycle(AddMotorcycleViewModel addMotorcycleViewModel, string userId)
        {
            var offer = new MotorcycleOffer()
            {
                Title = addMotorcycleViewModel.Title,
                Make = addMotorcycleViewModel.Make,
                Model = addMotorcycleViewModel.Model,
                Year = addMotorcycleViewModel.Year,
                Price = addMotorcycleViewModel.Price,
                Color = addMotorcycleViewModel.Color,
                FuelType = addMotorcycleViewModel.FuelType,
                Gearbox = addMotorcycleViewModel.Gearbox,
                Condition = addMotorcycleViewModel.Condition,
                HorsePower = addMotorcycleViewModel.HorsePower,
                CubicCentimeters = addMotorcycleViewModel.CubicCentimeters,
                Kilometers = addMotorcycleViewModel.Kilometers,
                Description = addMotorcycleViewModel.Description,
                ContactNumber = addMotorcycleViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow,
            };

            using (var target = new MemoryStream())
            {
                addMotorcycleViewModel.MainImageFile.CopyTo(target);
                offer.OfferImage = target.ToArray();
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == userId);
            offer.User = user;
            offer.UserId = userId;

            dbContext.MotorcycleOffers.Add(offer);
            dbContext.SaveChanges();

            var offerType = "MotorcycleOffer";

            if (addMotorcycleViewModel.SecondImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addMotorcycleViewModel.SecondImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addMotorcycleViewModel.ThirdImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addMotorcycleViewModel.ThirdImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addMotorcycleViewModel.FourthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addMotorcycleViewModel.FourthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addMotorcycleViewModel.FifthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addMotorcycleViewModel.FifthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addMotorcycleViewModel.SixthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addMotorcycleViewModel.SixthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            dbContext.SaveChanges();
        }

        public void AddElectricScooter(AddElectricScooterViewModel addScooterViewModel, string userId)
        {
            var offer = new ElectricScooterOffer()
            {
                Title = addScooterViewModel.Title,
                Make = addScooterViewModel.Make,
                Model = addScooterViewModel.Model,
                Year = addScooterViewModel.Year,
                Price = addScooterViewModel.Price,
                MaxSpeedAchievable = addScooterViewModel.MaxSpeedAchievable,
                Battery = addScooterViewModel.Battery,
                MaxWeight = addScooterViewModel.MaxWeight,
                MotorPower = addScooterViewModel.MotorPower,
                ScooterSize = addScooterViewModel.ScooterSize,
                TiresSize = addScooterViewModel.TiresSize,
                TravellingDistance = addScooterViewModel.TravellingDistance,
                WaterproofLevel = addScooterViewModel.WaterproofLevel,
                Condition = addScooterViewModel.Condition,
                Kilometers = addScooterViewModel.Kilometers,
                Description = addScooterViewModel.Description,
                ContactNumber = addScooterViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow,
            };

            using (var target = new MemoryStream())
            {
                addScooterViewModel.MainImageFile.CopyTo(target);
                offer.OfferImage = target.ToArray();
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == userId);
            offer.User = user;
            offer.UserId = userId;

            dbContext.ElectricScooterOffers.Add(offer);
            dbContext.SaveChanges();

            var offerType = "ElectricScooterOffer";

            if (addScooterViewModel.SecondImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addScooterViewModel.SecondImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addScooterViewModel.ThirdImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addScooterViewModel.ThirdImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addScooterViewModel.FourthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addScooterViewModel.FourthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addScooterViewModel.FifthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addScooterViewModel.FifthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addScooterViewModel.SixthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addScooterViewModel.SixthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id, offerType);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            dbContext.SaveChanges();
        }
        protected OfferImage GetOfferImage(MemoryStream target, int offerId, string offerType)
        {
            var offerImage = new OfferImage()
            {
                Image = target.ToArray(),
            };

            if (offerType == "CarOffer")
            {
                offerImage.CarOfferId = offerId;
            }
            else if (offerType == "MotorcycleOffer")
            {
                offerImage.MotorcycleOfferId = offerId;
            }
            else if (offerType == "ElectricScooterOffer")
            {
                offerImage.ElectricScooterOfferId = offerId;
            }

            return offerImage;
        }
    }
}