using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.ViewModels.ElectricScooters;
using AutomobileProject.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileProject.Services.ElectricScooters
{
    public class ElectricScootersService : IElectricScootersService
    {
        private readonly AutomobileDbContext dbContext;

        public ElectricScootersService(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<VisualizeScooterViewModel> ScootersForVisualization()
        {
            var scooterOffersToVisualize = new List<VisualizeScooterViewModel>();


            foreach (var scooterOffer in dbContext.ElectricScooterOffers.ToArray())
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                scooterOffersToVisualize.Add(scooter);
            }

            return scooterOffersToVisualize;
        }

        public ICollection<VisualizeScooterViewModel> ScootersForVisualization(string sortingType)
        {
            var scooterOffersToVisualize = new List<VisualizeScooterViewModel>();

            var scooterOffers = dbContext.ElectricScooterOffers.ToList();

            if (sortingType == "UploadDate")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.CreatedOn).ToList();
            }

            else if (sortingType == "LowestPrice")
            {
                scooterOffers = scooterOffers.OrderBy(x => x.Price).ToList();
            }
            else if (sortingType == "HighestPrice")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.Price).ToList();
            }

            else if (sortingType == "OldestYear")
            {
                scooterOffers = scooterOffers.OrderBy(x => x.Year).ToList();
            }
            else if (sortingType == "NewestYear")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.Year).ToList();
            }

            foreach (var scooterOffer in scooterOffers)
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                scooterOffersToVisualize.Add(scooter);
            }

            return scooterOffersToVisualize;
        }

        public ICollection<VisualizeScooterViewModel> ScootersForVisualization(FiltersInputModel filtersInput)
        {
            var scooterOffersToVisualize = new List<VisualizeScooterViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var scooterOffers = dbContext.ElectricScooterOffers.FromSqlRaw(
                "select * from ElectricScooterOffers " +
                $"where {filtersQuery}")
                .ToList();


            foreach (var scooterOffer in scooterOffers)
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                scooterOffersToVisualize.Add(scooter);
            }

            return scooterOffersToVisualize;
        }

        public ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId)
        {
            var userScooterOffersToVisualize = new List<VisualizeScooterViewModel>();

            foreach (var scooterOffer in dbContext.ElectricScooterOffers.Where(x => x.UserId == userId).ToArray())
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                userScooterOffersToVisualize.Add(scooter);
            }

            return userScooterOffersToVisualize;
        }

        public ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId, string sortingType)
        {
            var userScooterOffersToVisualize = new List<VisualizeScooterViewModel>();

            var scooterOffers = dbContext.ElectricScooterOffers.Where(x => x.UserId == userId).ToList();

            if (sortingType == "UploadDate")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.CreatedOn).ToList();
            }

            else if (sortingType == "LowestPrice")
            {
                scooterOffers = scooterOffers.OrderBy(x => x.Price).ToList();
            }
            else if (sortingType == "HighestPrice")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.Price).ToList();
            }

            else if (sortingType == "OldestYear")
            {
                scooterOffers = scooterOffers.OrderBy(x => x.Year).ToList();
            }
            else if (sortingType == "NewestYear")
            {
                scooterOffers = scooterOffers.OrderByDescending(x => x.Year).ToList();
            }

            foreach (var scooterOffer in scooterOffers)
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                userScooterOffersToVisualize.Add(scooter);
            }

            return userScooterOffersToVisualize;
        }


        public ICollection<VisualizeScooterViewModel> GetOnlyUserScooters(string userId, FiltersInputModel filtersInput)
        {
            var scooterOffersToVisualize = new List<VisualizeScooterViewModel>();

            var filtersQuery = GetFiltersAsQuery(filtersInput);

            var scooterOffers = dbContext.ElectricScooterOffers.FromSqlRaw(
                "select * from ElectricScooterOffers " +
                $"where {filtersQuery}")
                .ToList();


            foreach (var scooterOffer in scooterOffers.Where(x => x.UserId == userId))
            {
                var scooter = new VisualizeScooterViewModel()
                {
                    Id = scooterOffer.Id,
                    Title = scooterOffer.Title,
                    Condition = scooterOffer.Condition.ToString(),
                    Year = scooterOffer.Year,
                    Price = scooterOffer.Price,
                    Kilometers = scooterOffer.Kilometers,
                    MotorPower = scooterOffer.MotorPower,
                    WaterproofLevel = scooterOffer.WaterproofLevel,
                    Battery = scooterOffer.Battery
                };

                scooter.Image = ConvertByteArrayToImage(scooterOffer.OfferImage);

                scooterOffersToVisualize.Add(scooter);
            }

            return scooterOffersToVisualize;
        }
        public VisualizeScooterDetailsViewModel GetScooterById(int id)
        {
            var scooterOffer = dbContext.ElectricScooterOffers.FirstOrDefault(x => x.Id == id);

            var scooter = new VisualizeScooterDetailsViewModel()
            {
                Condition = scooterOffer.Condition.ToString(),
                Make = scooterOffer.Make,
                Model = scooterOffer.Model,
                Year = scooterOffer.Year,
                Kilometers = scooterOffer.Kilometers,
                Battery = scooterOffer.Battery,
                MotorPower = scooterOffer.MotorPower,
                Price = scooterOffer.Price,
                Description = scooterOffer.Description,
                MaxSpeedAchievable = scooterOffer.MaxSpeedAchievable,
                MaxWeight = scooterOffer.MaxWeight,
                ScooterSize = scooterOffer.ScooterSize,
                TiresSize = scooterOffer.TiresSize,
                TravellingDistance = scooterOffer.TravellingDistance,
                WaterproofLevel = scooterOffer.WaterproofLevel,
            };

            scooter.MainImage = ConvertByteArrayToImage(scooterOffer.OfferImage);
            scooter.Images.Add(ConvertByteArrayToImage(scooterOffer.OfferImage));

            foreach (var offerImage in dbContext.OfferImages.Where(x => x.ElectricScooterOfferId == scooterOffer.Id).ToList())
            {
                scooter.Images.Add(ConvertByteArrayToImage(offerImage.Image));
            }

            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == scooterOffer.UserId);

            var userDetails = new UserViewModel()
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email
            };

            scooter.UserDetails = userDetails;

            return scooter;
        }
        public ElectricScooterOffer GetScooterOfferById(int offerId)
        {
            return dbContext.ElectricScooterOffers.FirstOrDefault(x => x.Id == offerId);
        }

        public void DeleteScooterOffer(ElectricScooterOffer scooterOffer)
        {
            var offerImages = dbContext.OfferImages.Where(x => x.ElectricScooterOfferId == scooterOffer.Id).ToList();
            dbContext.OfferImages.RemoveRange(offerImages);

            dbContext.ElectricScooterOffers.Remove(scooterOffer);
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

            bool makeFilter = false;
            bool modelFilter = false;
            bool priceRangeFilter = false;

            if (filtersInput.Condition != 0)
            {
                filters += $"Condition = {(int)filtersInput.Condition} ";
            }
            else
            {
                if (filtersInput.Make != "All" && filtersInput.Make != "-- All --")
                {
                    filters += $"Make = '{filtersInput.Make}' ";
                    makeFilter = true;
                }
                else
                {
                    if (filtersInput.Model != "-- All --" && filtersInput.Model != "All")
                    {
                        filters += $"Model = '{filtersInput.Model}' ";
                        makeFilter = true;
                    }
                    else
                    {
                        filters += $"(Price >= {filtersInput.MinPrice} and Price <= {filtersInput.MaxPrice}) ";
                        priceRangeFilter = true;
                    }
                }
            }

            if ((filtersInput.Make != "All" && filtersInput.Make != "-- All --") && makeFilter == false)
            {
                filters += $"and Make = '{filtersInput.Make}' ";
            }

            if ((filtersInput.Model != "-- All --" && filtersInput.Model != "All") && modelFilter == false)
            {
                filters += $"and Model = '{filtersInput.Model}' ";
            }

            if (!priceRangeFilter)
            {
                filters += $"and (Price >= {filtersInput.MinPrice} and Price <= {filtersInput.MaxPrice}) ";
            }

            filters += $"and (Kilometers >= {filtersInput.MinKilometers} and Kilometers <= {filtersInput.MaxKilometers}) ";
            filters += $"and (MotorPower >= {filtersInput.MinMotorPower} and MotorPower <= {filtersInput.MaxMotorPower}) ";

            return filters;
        }
    }
}
