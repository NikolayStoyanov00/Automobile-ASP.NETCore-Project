using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.Motorcycles;
using AutomobileProject.Views.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileProject.Services.Motorcycles
{
    public class MotorcyclesService : IMotorcyclesService
    {
        private AutomobileDbContext dbContext;

        public MotorcyclesService(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<VisualizeMotorcycleViewModel> MotorcyclesForVisualization(FiltersInputModel filtersInput)
        {
            var motorcycleOffersToVisualize = new List<VisualizeMotorcycleViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var motorcycleOffers = dbContext.MotorcycleOffers.FromSqlRaw(
                "select * from MotorcycleOffers " +
                $"where {filtersQuery}")
                .ToList();

            foreach (var motorcycleOffer in motorcycleOffers)
            {
                var motorcycle = new VisualizeMotorcycleViewModel()
                {
                    Id = motorcycleOffer.Id,
                    Title = motorcycleOffer.Title,
                    Condition = motorcycleOffer.Condition.ToString(),
                    Year = motorcycleOffer.Year,
                    FuelType = motorcycleOffer.FuelType.ToString(),
                    HorsePower = motorcycleOffer.HorsePower,
                    Price = motorcycleOffer.Price,
                    Kilometers = motorcycleOffer.Kilometers,
                    CubicCentimeters = motorcycleOffer.CubicCentimeters,
                    Gearbox = motorcycleOffer.Gearbox.ToString(),
                };

                motorcycle.Image = ConvertByteArrayToImage(motorcycleOffer.OfferImage);

                motorcycleOffersToVisualize.Add(motorcycle);
            }

            return motorcycleOffersToVisualize;
        }

        public ICollection<VisualizeMotorcycleViewModel> MotorcyclesForVisualization()
        {
            var motorcycleOffersToVisualize = new List<VisualizeMotorcycleViewModel>();

            foreach (var motorcycleOffer in dbContext.MotorcycleOffers.ToArray())
            {
                var motorcycle = new VisualizeMotorcycleViewModel()
                {
                    Id = motorcycleOffer.Id,
                    Title = motorcycleOffer.Title,
                    Condition = motorcycleOffer.Condition.ToString(),
                    Year = motorcycleOffer.Year,
                    FuelType = motorcycleOffer.FuelType.ToString(),
                    HorsePower = motorcycleOffer.HorsePower,
                    Price = motorcycleOffer.Price,
                    Kilometers = motorcycleOffer.Kilometers,
                    CubicCentimeters = motorcycleOffer.CubicCentimeters,
                    Gearbox = motorcycleOffer.Gearbox.ToString(),
                };

                motorcycle.Image = ConvertByteArrayToImage(motorcycleOffer.OfferImage);

                motorcycleOffersToVisualize.Add(motorcycle);
            }

            return motorcycleOffersToVisualize;
        }

        public VisualizeMotorcycleDetailsViewModel GetMotorcycleById(int id)
        {
            var motorcycleOffer = dbContext.MotorcycleOffers.FirstOrDefault(x => x.Id == id);

            var motorcycle = new VisualizeMotorcycleDetailsViewModel()
            {
                Type = motorcycleOffer.Condition.ToString(),
                Make = motorcycleOffer.Make,
                Model = motorcycleOffer.Model,
                Year = motorcycleOffer.Year,
                Kilometers = motorcycleOffer.Kilometers,
                FuelType = motorcycleOffer.FuelType.ToString(),
                HorsePower = motorcycleOffer.HorsePower,
                Price = motorcycleOffer.Price,
                Description = motorcycleOffer.Description,
                CubicCentimeters = motorcycleOffer.CubicCentimeters,
                Gearbox = motorcycleOffer.Gearbox.ToString(),
                Color = motorcycleOffer.Color,
            };

            motorcycle.MainImage = ConvertByteArrayToImage(motorcycleOffer.OfferImage);
            motorcycle.Images.Add(ConvertByteArrayToImage(motorcycleOffer.OfferImage));

            foreach (var offerImage in dbContext.OfferImages.Where(x => x.MotorcycleOfferId == motorcycleOffer.Id).ToList())
            {
                motorcycle.Images.Add(ConvertByteArrayToImage(offerImage.Image));
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == motorcycleOffer.UserId);

            var userDetails = new UserViewModel()
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email
            };

            motorcycle.UserDetails = userDetails;

            return motorcycle;
        }

        public ICollection<VisualizeMotorcycleViewModel> GetOnlyUserMotorcycles(string userId)
        {
            var userMotorcycleOffersToVisualize = new List<VisualizeMotorcycleViewModel>();

            foreach (var motorcycleOffer in dbContext.MotorcycleOffers.Where(x => x.UserId == userId).ToArray())
            {
                var motorcycle = new VisualizeMotorcycleViewModel()
                {
                    Id = motorcycleOffer.Id,
                    Title = motorcycleOffer.Title,
                    Condition = motorcycleOffer.Condition.ToString(),
                    Year = motorcycleOffer.Year,
                    FuelType = motorcycleOffer.FuelType.ToString(),
                    HorsePower = motorcycleOffer.HorsePower,
                    Price = motorcycleOffer.Price,
                    Kilometers = motorcycleOffer.Kilometers,
                    CubicCentimeters = motorcycleOffer.CubicCentimeters,
                    Gearbox = motorcycleOffer.Gearbox.ToString(),
                };

                motorcycle.Image = ConvertByteArrayToImage(motorcycleOffer.OfferImage);

                userMotorcycleOffersToVisualize.Add(motorcycle);
            }

            return userMotorcycleOffersToVisualize;
        }
        public ICollection<VisualizeMotorcycleViewModel> GetOnlyUserMotorcycles(string userId, FiltersInputModel filtersInput)
        {
            var motorcycleOffersToVisualize = new List<VisualizeMotorcycleViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var motorcycleOffers = dbContext.MotorcycleOffers.FromSqlRaw(
                "select * from MotorcycleOffers " +
                $"where {filtersQuery}")
                .ToList();

            foreach (var motorcycleOffer in motorcycleOffers.Where(x => x.UserId == userId))
            {
                var motorcycle = new VisualizeMotorcycleViewModel()
                {
                    Id = motorcycleOffer.Id,
                    Title = motorcycleOffer.Title,
                    Condition = motorcycleOffer.Condition.ToString(),
                    Year = motorcycleOffer.Year,
                    FuelType = motorcycleOffer.FuelType.ToString(),
                    HorsePower = motorcycleOffer.HorsePower,
                    Price = motorcycleOffer.Price,
                    Kilometers = motorcycleOffer.Kilometers,
                    CubicCentimeters = motorcycleOffer.CubicCentimeters,
                    Gearbox = motorcycleOffer.Gearbox.ToString(),
                };

                motorcycle.Image = ConvertByteArrayToImage(motorcycleOffer.OfferImage);

                motorcycleOffersToVisualize.Add(motorcycle);
            }

            return motorcycleOffersToVisualize;
        }

        public MotorcycleOffer GetMotorcycleOfferById(int offerId)
        {
            return dbContext.MotorcycleOffers.FirstOrDefault(x => x.Id == offerId);
        }

        public void DeleteMotorcycleOffer(MotorcycleOffer motorcycleOffer)
        {
            var offerImages = dbContext.OfferImages.Where(x => x.MotorcycleOfferId == motorcycleOffer.Id).ToList();
            dbContext.OfferImages.RemoveRange(offerImages);

            dbContext.MotorcycleOffers.Remove(motorcycleOffer);
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
            filters += $"and (Year >= {filtersInput.MinYear} and Year <= {filtersInput.MaxYear}) ";

            return filters;
        }
    }
}
