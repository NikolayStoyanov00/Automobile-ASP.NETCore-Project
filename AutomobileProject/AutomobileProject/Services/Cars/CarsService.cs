using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.Data.Models.User;
using AutomobileProject.ViewModels.Offer;
using AutomobileProject.Views.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Services.Offer
{
    public class CarsService : ICarsService
    {
        private readonly AutomobileDbContext dbContext;

        public CarsService(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<VisualizeCarViewModel> CarsForVisualization()
        {
            var carOffersToVisualize = new List<VisualizeCarViewModel>();
            
            foreach (var carOffer in dbContext.CarOffers.ToArray())
            {
                var car = new VisualizeCarViewModel()
                {
                    Id = carOffer.Id,
                    Title = carOffer.Title,
                    Condition = carOffer.Condition,
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType,
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox,
                    Doors = carOffer.Doors
                };

                car.Image = ConvertByteArrayToImage(carOffer.OfferImage); 

                carOffersToVisualize.Add(car);
            }

            return carOffersToVisualize;
        }

        public VisualizeCarDetailsViewModel GetCarById(int id)
        {
            var carOffer = dbContext.CarOffers.FirstOrDefault(x => x.Id == id);

            var car = new VisualizeCarDetailsViewModel()
            {
                Type = carOffer.Condition,
                Make = carOffer.Make,
                Model = carOffer.Model,
                Year = carOffer.Year,
                Kilometers = carOffer.Kilometers,
                FuelType = carOffer.FuelType,
                HorsePower = carOffer.HorsePower,
                Price = carOffer.Price,
                Description = carOffer.Description,
                EngineSize = carOffer.EngineSize,
                Gearbox = carOffer.Gearbox,
                Color = carOffer.Color,
                Doors = carOffer.Doors
            };

            car.MainImage = ConvertByteArrayToImage(carOffer.OfferImage);
            car.Images.Add(ConvertByteArrayToImage(carOffer.OfferImage));

            foreach (var offerImage in dbContext.OfferImages.Where(x => x.CarOfferId == carOffer.Id).ToList())
            {
                car.Images.Add(ConvertByteArrayToImage(offerImage.Image));
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == carOffer.UserId);

            var userDetails = new UserViewModel()
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email
            };

            car.UserDetails = userDetails;

            return car;
        }

        private string ConvertByteArrayToImage(byte[] arrayImage)
        {
            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;
        }
    }
}