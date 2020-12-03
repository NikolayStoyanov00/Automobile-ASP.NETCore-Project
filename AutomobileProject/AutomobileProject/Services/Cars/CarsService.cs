using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.Data.Models.User;
using AutomobileProject.ViewModels.Cars;
using AutomobileProject.ViewModels.Offer;
using AutomobileProject.Views.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                    Condition = carOffer.Condition.ToString(),
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType.ToString(),
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox.ToString(),
                    Doors = carOffer.Doors
                };

                car.Image = ConvertByteArrayToImage(carOffer.OfferImage);

                carOffersToVisualize.Add(car);
            }

            return carOffersToVisualize;
        }

        public ICollection<VisualizeCarViewModel> CarsForVisualization(FiltersInputModel filtersInput)
        {
            var carOffersToVisualize = new List<VisualizeCarViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var carOffers = dbContext.CarOffers.FromSqlRaw(
                "select * from CarOffers " +
                $"where {filtersQuery}")
                .ToList();


            foreach (var carOffer in carOffers)
            {
                var car = new VisualizeCarViewModel()
                {
                    Id = carOffer.Id,
                    Title = carOffer.Title,
                    Condition = carOffer.Condition.ToString(),
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType.ToString(),
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox.ToString(),
                    Doors = carOffer.Doors
                };

                car.Image = ConvertByteArrayToImage(carOffer.OfferImage);

                carOffersToVisualize.Add(car);
            }

            return carOffersToVisualize;
        }

        public ICollection<VisualizeCarViewModel> CarsForFeaturing()
        {
            var carOffersToVisualize = new List<VisualizeCarViewModel>();


            foreach (var carOffer in dbContext.CarOffers.OrderByDescending(x => x.CreatedOn).Take(6).ToArray())
            {
                var car = new VisualizeCarViewModel()
                {
                    Id = carOffer.Id,
                    Title = carOffer.Title,
                    Condition = carOffer.Condition.ToString(),
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType.ToString(),
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox.ToString(),
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
                Type = carOffer.Condition.ToString(),
                Make = carOffer.Make,
                Model = carOffer.Model,
                Year = carOffer.Year,
                Kilometers = carOffer.Kilometers,
                FuelType = carOffer.FuelType.ToString(),
                HorsePower = carOffer.HorsePower,
                Price = carOffer.Price,
                Description = carOffer.Description,
                EngineSize = carOffer.EngineSize,
                Gearbox = carOffer.Gearbox.ToString(),
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

        public ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId)
        {
            var userCarOffersToVisualize = new List<VisualizeCarViewModel>();

            foreach (var carOffer in dbContext.CarOffers.Where(x => x.UserId == userId).ToArray())
            {
                var car = new VisualizeCarViewModel()
                {
                    Id = carOffer.Id,
                    Title = carOffer.Title,
                    Condition = carOffer.Condition.ToString(),
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType.ToString(),
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox.ToString(),
                    Doors = carOffer.Doors
                };

                car.Image = ConvertByteArrayToImage(carOffer.OfferImage);

                userCarOffersToVisualize.Add(car);
            }

            return userCarOffersToVisualize;
        }

        
        public CarOffer GetCarOfferById(int offerId)
        {
            return dbContext.CarOffers.FirstOrDefault(x => x.Id == offerId);
        }

        public void DeleteCarOffer(CarOffer carOffer)
        {
            dbContext.CarOffers.Remove(carOffer);
            dbContext.SaveChanges();
        }

        private string ConvertByteArrayToImage(byte[] arrayImage)
        {
            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;
        }

        private string GetFiltersAsQuery(FiltersInputModel filtersInput)
        {
            var filters = "";

            bool colorFilter = false;
            bool makeFilter = false;
            bool modelFilter = false;
            bool fuelTypeFilter = false;
            bool gearboxFilter = false;
            bool doorsFilter = false;
            bool steeringWheelSideFilter = false;
            bool priceRangeFilter = false;

            if (filtersInput.Condition != 0)
            {
                filters += $"Condition = {(int)filtersInput.Condition} ";
            }
            else
            {
                if (filtersInput.Color != null)
                {
                    filters += $"Color = '{filtersInput.Color}' ";
                    colorFilter = true;
                }
                else
                {
                    if (filtersInput.Make != "All")
                    {
                        filters += $"Make = '{filtersInput.Make}' ";
                        makeFilter = true;
                    }
                    else
                    {
                        if (filtersInput.Model != "-- All --")
                        {
                            filters += $"Model = '{filtersInput.Model}' ";
                            modelFilter = true;
                        }
                        else
                        {
                            if (filtersInput.Doors != "All")
                            {
                                filters += $"Doors = '{filtersInput.Doors}' ";
                                doorsFilter = true;
                            }
                            else
                            {
                                if (filtersInput.FuelType != 0)
                                {
                                    filters += $"FuelType = {(int)filtersInput.FuelType}";
                                    fuelTypeFilter = true;
                                }
                                else
                                {
                                    if (filtersInput.Gearbox != 0)
                                    {
                                        filters += $"Gearbox = {(int)filtersInput.Gearbox} ";
                                        gearboxFilter = true;
                                    }
                                    else
                                    {
                                        if (filtersInput.SteeringWheelSide != 0)
                                        {
                                            filters += $"SteeringWheelSide = {(int)filtersInput.SteeringWheelSide} ";
                                            steeringWheelSideFilter = true;
                                        }
                                        else
                                        {
                                            filters += $"(Price >= {filtersInput.MinPrice} and Price <= {filtersInput.MaxPrice}) ";
                                            priceRangeFilter = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (filtersInput.Color != null && colorFilter == false)
            {
                filters += $"and Color = '{filtersInput.Color}' ";
            }

            if (filtersInput.Make != "All" && makeFilter == false)
            {
                filters += $"and Make = '{filtersInput.Make}' ";
            }

            if (filtersInput.Model != "-- All --" && modelFilter == false)
            {
                filters += $"and Model = '{filtersInput.Model}' ";
            }

            if (filtersInput.Doors != "All" && doorsFilter == false)
            {
                filters += $"and Doors = '{filtersInput.Doors}' ";
            }

            if (filtersInput.FuelType != 0 && fuelTypeFilter == false)
            {
                filters += $"and FuelType = {(int)filtersInput.FuelType} ";
            }

            if (filtersInput.Gearbox != 0 && gearboxFilter == false)
            {
                filters += $"and Gearbox = {(int)filtersInput.Gearbox} ";
            }

            if (filtersInput.SteeringWheelSide != 0 && steeringWheelSideFilter == false)
            {
                filters += $"and SteeringWheelSide = {(int)filtersInput.SteeringWheelSide} ";
            }

            if (priceRangeFilter == false)
            {
                filters += $"and (Price >= {filtersInput.MinPrice} and Price <= {filtersInput.MaxPrice}) ";
            } 

            filters += $"and (Kilometers >= {filtersInput.MinKilometers} and Kilometers <= {filtersInput.MaxKilometers}) ";
            filters += $"and (HorsePower >= {filtersInput.MinHorsePower} and HorsePower <= {filtersInput.MaxHorsePower}) ";
            filters += $"and (Year >= {filtersInput.MinYear} and Year <= {filtersInput.MaxYear}) ";

            return filters;
        }

        public ICollection<VisualizeCarViewModel> GetOnlyUserCars(string userId, FiltersInputModel filtersInput)
        {
            var carOffersToVisualize = new List<VisualizeCarViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var carOffers = dbContext.CarOffers.FromSqlRaw(
                "select * from CarOffers " +
                $"where {filtersQuery}")
                .ToList();


            foreach (var carOffer in carOffers.Where(x => x.UserId == userId))
            {
                var car = new VisualizeCarViewModel()
                {
                    Id = carOffer.Id,
                    Title = carOffer.Title,
                    Condition = carOffer.Condition.ToString(),
                    Year = carOffer.Year,
                    FuelType = carOffer.FuelType.ToString(),
                    HorsePower = carOffer.HorsePower,
                    Price = carOffer.Price,
                    Kilometers = carOffer.Kilometers,
                    EngineSize = carOffer.EngineSize,
                    Gearbox = carOffer.Gearbox.ToString(),
                    Doors = carOffer.Doors
                };

                car.Image = ConvertByteArrayToImage(carOffer.OfferImage);

                carOffersToVisualize.Add(car);
            }

            return carOffersToVisualize;
        }
    }
}