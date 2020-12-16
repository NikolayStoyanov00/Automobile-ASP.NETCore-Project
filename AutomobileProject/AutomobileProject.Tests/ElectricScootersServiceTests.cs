using AutomobileProject.Data.Models;
using AutomobileProject.Services.ElectricScooters;
using AutomobileProject.ViewModels.Cars.Enums;
using AutomobileProject.ViewModels.ElectricScooters;
using System;
using System.Linq;
using Xunit;

namespace AutomobileProject.Tests
{
    public class ElectricScootersServiceTests
    {
        [Fact]
        public void CheckIfScootersForVisualizationAreEqualToScootersInDb()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var scootersCollection = service.ScootersForVisualization();
            var scootersAvailableInDb = dbContext.ElectricScooterOffers.ToList();

            Assert.True(scootersCollection.Count == scootersAvailableInDb.Count);
        }

        [Fact]
        public void CheckIfScootersForVisualizationBySortingTypeAreSortedCorrectly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var scootersCollection = service.ScootersForVisualization("UploadDate");
            var scootersAvailableInDb = dbContext.ElectricScooterOffers.OrderByDescending(x => x.CreatedOn).ToList();

            Assert.Equal(scootersCollection.First().Id, scootersAvailableInDb.First().Id);

            scootersCollection = service.ScootersForVisualization("LowestPrice");
            scootersAvailableInDb = dbContext.ElectricScooterOffers.OrderBy(x => x.Price).ToList();

            Assert.Equal(scootersCollection.First().Id, scootersAvailableInDb.First().Id);

            scootersCollection = service.ScootersForVisualization("HighestPrice");
            scootersAvailableInDb = dbContext.ElectricScooterOffers.OrderByDescending(x => x.Price).ToList();

            Assert.Equal(scootersCollection.First().Id, scootersAvailableInDb.First().Id);

            scootersCollection = service.ScootersForVisualization("OldestYear");
            scootersAvailableInDb = dbContext.ElectricScooterOffers.OrderBy(x => x.Year).ToList();

            Assert.Equal(scootersCollection.First().Id, scootersAvailableInDb.First().Id);

            scootersCollection = service.ScootersForVisualization("NewestYear");
            scootersAvailableInDb = dbContext.ElectricScooterOffers.OrderByDescending(x => x.Year).ToList();

            Assert.Equal(scootersCollection.First().Id, scootersAvailableInDb.First().Id);
        }

        [Fact]
        public void CheckIfScootersForVisualizationByFiltersAreReturningCorrectOffers()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = Condition.New,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinMotorPower = 0,
                MaxMotorPower = 50000
            };

            var scootersCollection = service.ScootersForVisualization(filtersInputModel);

            var scootersAvailableInDb = dbContext.ElectricScooterOffers.Where(x =>
                x.Condition == Condition.New
                && x.Price >= 100);

            Assert.Equal(scootersCollection.Count(), scootersAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfGetScooterByIdReturnsCorrectScooter()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var scooterFromDb = dbContext.ElectricScooterOffers.FirstOrDefault();
            var scooterFromService = service.GetScooterById(scooterFromDb.Id);

            Assert.Equal(scooterFromDb.Id, scooterFromService.Id);
        }

        [Fact]
        public void CheckIfChangeScooterDetailsActuallyChangesTheDetails()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var scooterFromDb = dbContext.ElectricScooterOffers.FirstOrDefault();

            VisualizeScooterDetailsViewModel model = new VisualizeScooterDetailsViewModel()
            {
                Id = scooterFromDb.Id,
                Make = "Xiaomi",
                Model = "Pro",
                Kilometers = 150,
                Condition = "Used",
                MaxSpeedAchievable = 30,
                MaxWeight = 100,
                MotorPower = 500,
                TiresSize = 8.5m,
                ScooterSize = "paworoawrpo",
                TravellingDistance = 35,
                WaterproofLevel = "IP54",
                Price = 31231,
                Year = 2000,
                Battery = "new",
                Description = "testt"
            };

            service.ChangeScooterDetails(model);
            var priceAfterChangeScooterDetails = scooterFromDb.Price;
            Assert.Equal(priceAfterChangeScooterDetails, model.Price);
        }

        [Fact]
        public void CheckIfGetOnlyUserScootersReturnsTheScootersForThatParticularUserOnly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d");

            var dbOnlyUserScooters = dbContext.ElectricScooterOffers.Where(x => x.UserId == "b97261dd-b5c7-4c89-ab32-5d3934b2c85d");

            Assert.Equal(dbOnlyUserScooters.Count(), serviceOnlyUserScooters.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserScootersBySortingReturnsTheCorrectScootersForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", "UploadDate");

            var dbOnlyUserScooters = dbContext.ElectricScooterOffers.Where(x => x.UserId == "b97261dd-b5c7-4c89-ab32-5d3934b2c85d").OrderByDescending(x => x.CreatedOn).ToList();

            if (serviceOnlyUserScooters.Count == 0 && dbOnlyUserScooters.Count == 0)
            {
                Assert.Equal(dbOnlyUserScooters.Count(), serviceOnlyUserScooters.Count());
                return;
            }

            Assert.Equal(serviceOnlyUserScooters.FirstOrDefault().Title, dbOnlyUserScooters.FirstOrDefault().Title);

            serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", "LowestPrice");


            dbOnlyUserScooters = dbOnlyUserScooters
                .OrderBy(x => x.Price).ToList();

            Assert.Equal(serviceOnlyUserScooters.FirstOrDefault().Title, dbOnlyUserScooters.FirstOrDefault().Title);


            serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", "HighestPrice");

            dbOnlyUserScooters = dbOnlyUserScooters
                .OrderByDescending(x => x.Price).ToList();


            Assert.Equal(serviceOnlyUserScooters.FirstOrDefault().Title, dbOnlyUserScooters.FirstOrDefault().Title);

            serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", "OldestYear");


            dbOnlyUserScooters = dbOnlyUserScooters
                .OrderBy(x => x.Year).ToList();

            Assert.Equal(serviceOnlyUserScooters.FirstOrDefault().Title, dbOnlyUserScooters.FirstOrDefault().Title);


            serviceOnlyUserScooters = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", "NewestYear");

            dbOnlyUserScooters = dbOnlyUserScooters
                .OrderByDescending(x => x.Year).ToList();


            Assert.Equal(serviceOnlyUserScooters.FirstOrDefault().Title, dbOnlyUserScooters.FirstOrDefault().Title);

            Assert.Equal(dbOnlyUserScooters.Count(), serviceOnlyUserScooters.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserScootersByFiltersReturnsTheCorrectScootersForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = Condition.New,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinMotorPower = 0,
                MaxMotorPower = 5000
            };

            var scootersCollection = service.GetOnlyUserScooters("b97261dd-b5c7-4c89-ab32-5d3934b2c85d", filtersInputModel);

            var scootersAvailableInDb = dbContext.ElectricScooterOffers.Where(x =>
                x.Condition == Condition.New
                && x.Price >= 100 && x.UserId == "b97261dd-b5c7-4c89-ab32-5d3934b2c85d");

            Assert.Equal(scootersCollection.Count(), scootersAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfDeleteScooterOfferRemovesTheOfferFromTheDatabase()
        {
            var dbContext = new AutomobileDbContext();
            var service = new ElectricScootersService(dbContext);

            var dbOffer = dbContext.ElectricScooterOffers.FirstOrDefault();
            var offerImages = dbContext.OfferImages.Where(x => x.ElectricScooterOfferId == dbOffer.Id);

            var getScooterOfferById = service.GetScooterOfferById(dbOffer.Id);
            service.DeleteScooterOffer(getScooterOfferById);

            Assert.True(dbContext.ElectricScooterOffers.Any(x => x.Id == dbOffer.Id) == false);

            //Add removed scooter and images so that db remains the same. Set Offer Id  0 to not override identity for Id in database.
            getScooterOfferById.Id = 0;
            dbContext.ElectricScooterOffers.Add(getScooterOfferById);
            dbContext.OfferImages.AddRange(offerImages);
            dbContext.SaveChanges();
        }
    }
}