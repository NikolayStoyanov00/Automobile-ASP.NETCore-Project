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
                Condition = addCarViewModel.Condition.ToString(),
                Color = addCarViewModel.Color,
                SteeringWheelSide = addCarViewModel.SteeringWheelSide.ToString(),
                FuelType = addCarViewModel.FuelType.ToString(),
                HorsePower = addCarViewModel.HorsePower,
                EngineSize = addCarViewModel.EngineSize,
                Gearbox = addCarViewModel.Gearbox.ToString(),
                Doors = addCarViewModel.Doors,
                Kilometers = addCarViewModel.Kilometers,
                Description = addCarViewModel.Description,
                ContactNumber = addCarViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow,
            };

            using (var target = new MemoryStream())
            {
                addCarViewModel.MainImageFile.CopyTo(target);
                offer.OfferImage = target.ToArray();
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == userId);
            offer.User = user;
            offer.UserId = userId;

            dbContext.CarOffers.Add(offer);
            dbContext.SaveChanges();

            if (addCarViewModel.SecondImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.SecondImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.ThirdImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.ThirdImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.FourthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.FourthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.FifthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.FifthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id);
                    dbContext.OfferImages.Add(offerImage);
                }
            }

            if (addCarViewModel.SixthImageFile != null)
            {
                using (var target = new MemoryStream())
                {
                    addCarViewModel.SixthImageFile.CopyTo(target);
                    var offerImage = GetOfferImage(target, offer.Id);
                    dbContext.OfferImages.Add(offerImage);
                }
            }
           
            dbContext.SaveChanges();
        }

        protected OfferImage GetOfferImage(MemoryStream target, int offerId)
        {
            var offerImage = new OfferImage()
            {
                Image = target.ToArray(),
                CarOfferId = offerId
            };

            return offerImage;
        }

        public void AddMotorcycle(AddMotorcycleViewModel addMotorcycleViewModel)
        {
            var offer = new MotorcycleOffer()
            {
                Title = addMotorcycleViewModel.Title,
                Make = addMotorcycleViewModel.Make,
                Model = addMotorcycleViewModel.Model,
                Year = addMotorcycleViewModel.Year,
                Price = addMotorcycleViewModel.Price,
                Condition = addMotorcycleViewModel.Condition,
                HorsePower = addMotorcycleViewModel.HorsePower,
                CubicCentimers = addMotorcycleViewModel.CubicCentimeters,
                Kilometers = addMotorcycleViewModel.Kilometers,
                Description = addMotorcycleViewModel.Description,
                ContactNumber = addMotorcycleViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow
            };

            using (var target = new MemoryStream())
            {
                addMotorcycleViewModel.ImageFile.CopyTo(target);
                offer.ImageFile = target.ToArray();
            }

            dbContext.MotorcycleOffers.Add(offer);
            dbContext.SaveChanges();
        }
    }
}