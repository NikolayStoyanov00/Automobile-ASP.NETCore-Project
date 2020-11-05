using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Offer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        public void AddCar(AddCarViewModel addCarViewModel)
        {
            var offer = new CarOffer()
            {
                Title = addCarViewModel.Title,
                Make = addCarViewModel.Make,
                Model = addCarViewModel.Model,
                Year = addCarViewModel.Year,
                Price = addCarViewModel.Price,
                Condition = addCarViewModel.Condition.ToString(),
                FuelType = addCarViewModel.FuelType.ToString(),
                HorsePower = addCarViewModel.HorsePower,
                Kilometers = addCarViewModel.Kilometers,
                Description = addCarViewModel.Description,
                ContactNumber = addCarViewModel.ContactNumber,
                CreatedOn = DateTime.UtcNow,
            };

            using (var target = new MemoryStream())
            {
                addCarViewModel.ImageFile.CopyTo(target);
                offer.ImageFile = target.ToArray();
            }

            dbContext.CarOffers.Add(offer);
            dbContext.SaveChanges();
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
                    Kilometers = carOffer.Kilometers
                };

                car.Image = ConvertByteArrayToImage(carOffer.ImageFile); 

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
            };

            car.Image = ConvertByteArrayToImage(carOffer.ImageFile);

            return car;
        }

        private string ConvertByteArrayToImage(byte[] arrayImage)

        {
            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;

        }
    }
}