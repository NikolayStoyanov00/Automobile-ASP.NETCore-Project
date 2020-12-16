using AutomobileProject.Data.Models;
using AutomobileProject.Services.Motorcycles;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels.Cars.Enums;
using AutomobileProject.ViewModels.Motorcycles;
using System;
using System.Linq;
using Xunit;

namespace AutomobileProject.Tests
{
    public class MotorcyclesServiceTests
    {
        [Fact]
        public void CheckIfMotorcyclesForVisualizationAreEqualToMotorcyclesInDb()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var motorcyclesCollection = service.MotorcyclesForVisualization();
            var motorcyclesAvailableInDb = dbContext.MotorcycleOffers.ToList();

            Assert.True(motorcyclesCollection.Count == motorcyclesAvailableInDb.Count);
        }

        [Fact]
        public void CheckIfMotorcyclesForVisualizationBySortingTypeAreSortedCorrectly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var motorcyclesCollection = service.MotorcyclesForVisualization("UploadDate");
            var motorcyclesAvailableInDb = dbContext.MotorcycleOffers.OrderByDescending(x => x.CreatedOn).ToList();

            Assert.Equal(motorcyclesCollection.First().Id, motorcyclesAvailableInDb.First().Id);

            motorcyclesCollection = service.MotorcyclesForVisualization("LowestPrice");
            motorcyclesAvailableInDb = dbContext.MotorcycleOffers.OrderBy(x => x.Price).ToList();

            Assert.Equal(motorcyclesCollection.First().Id, motorcyclesAvailableInDb.First().Id);

            motorcyclesCollection = service.MotorcyclesForVisualization("HighestPrice");
            motorcyclesAvailableInDb = dbContext.MotorcycleOffers.OrderByDescending(x => x.Price).ToList();

            Assert.Equal(motorcyclesCollection.First().Id, motorcyclesAvailableInDb.First().Id);

            motorcyclesCollection = service.MotorcyclesForVisualization("OldestYear");
            motorcyclesAvailableInDb = dbContext.MotorcycleOffers.OrderBy(x => x.Year).ToList();

            Assert.Equal(motorcyclesCollection.First().Id, motorcyclesAvailableInDb.First().Id);

            motorcyclesCollection = service.MotorcyclesForVisualization("NewestYear");
            motorcyclesAvailableInDb = dbContext.MotorcycleOffers.OrderByDescending(x => x.Year).ToList();

            Assert.Equal(motorcyclesCollection.First().Id, motorcyclesAvailableInDb.First().Id);
        }

        [Fact]
        public void CheckIfMotorcyclesForVisualizationByFiltersAreReturningCorrectOffers()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = Condition.New,
                FuelType = FuelType.Petrol,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                Gearbox = 0,
                SteeringWheelSide = 0,
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinYear = 1900,
                MaxYear = DateTime.Now.Year,
            };

            var motorcyclesCollection = service.MotorcyclesForVisualization(filtersInputModel);
            var motorcyclesAvailableInDb = dbContext.MotorcycleOffers.Where(x =>
                x.Condition == Condition.New
                && x.FuelType == FuelType.Petrol
                && x.Price >= 100);

            Assert.Equal(motorcyclesCollection.Count(), motorcyclesAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfGetMotorcycleByIdReturnsCorrectMotorcycle()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var motorcycleFromDb = dbContext.MotorcycleOffers.FirstOrDefault();
            var motorcycleFromService = service.GetMotorcycleById(motorcycleFromDb.Id);

            Assert.Equal(motorcycleFromDb.Id, motorcycleFromService.Id);
        }

        [Fact]
        public void CheckIfChangeMotorcycleDetailsActuallyChangesTheDetails()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var motorcycleFromDb = dbContext.MotorcycleOffers.FirstOrDefault();
            VisualizeMotorcycleDetailsViewModel model = new VisualizeMotorcycleDetailsViewModel()
            {
                Id = motorcycleFromDb.Id,
                Type = "New",
                Make = "BMW",
                Model = "HB2",
                Kilometers = 150,
                FuelType = "Diesel",
                Gearbox = "Manual",
                HorsePower = 32,
                Price = 5000,
                CubicCentimeters = 650,
                Color = "black",
                Year = 2000,
                Description = "testt"
            };

            service.ChangeMotorcycleDetails(model);
            var priceAfterChangeMotorcycleDetails = motorcycleFromDb.Price;
            Assert.Equal(priceAfterChangeMotorcycleDetails, model.Price);
        }

        [Fact]
        public void CheckIfGetOnlyUserMotorcyclesReturnsTheMotorcyclesForThatParticularUserOnly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992cc46-4ebbbaf2-667f245a3582");

            var dbOnlyUserMotorcycles = dbContext.MotorcycleOffers.Where(x => x.UserId == "e4bf2992cc46-4ebb-baf2-667f245a3582");

            Assert.Equal(dbOnlyUserMotorcycles.Count(), serviceOnlyUserMotorcycles.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserMotorcyclesBySortingReturnsTheCorrectMotorcyclesForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebbbaf2-667f245a3582", "UploadDate");

            var dbOnlyUserMotorcycles = dbContext.MotorcycleOffers.Where(x => x.UserId == "e4bf2992cc46-4ebb-baf2-667f245a3582").OrderByDescending(x => x.CreatedOn).ToList();

            if (serviceOnlyUserMotorcycles.Count == 0 && dbOnlyUserMotorcycles.Count == 0)
            {
                Assert.Equal(dbOnlyUserMotorcycles.Count(), serviceOnlyUserMotorcycles.Count());
                return;
            }

            Assert.Equal(serviceOnlyUserMotorcycles.FirstOrDefault().Title, dbOnlyUserMotorcycles.FirstOrDefault().Title);

            serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebbbaf2-667f245a3582", "LowestPrice");


            dbOnlyUserMotorcycles = dbOnlyUserMotorcycles
                .OrderBy(x => x.Price).ToList();

            Assert.Equal(serviceOnlyUserMotorcycles.FirstOrDefault().Title, dbOnlyUserMotorcycles.FirstOrDefault().Title);


            serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebbbaf2-667f245a3582", "HighestPrice");

            dbOnlyUserMotorcycles = dbOnlyUserMotorcycles
                .OrderByDescending(x => x.Price).ToList();


            Assert.Equal(serviceOnlyUserMotorcycles.FirstOrDefault().Title, dbOnlyUserMotorcycles.FirstOrDefault().Title);

            serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebbbaf2-667f245a3582", "OldestYear");


            dbOnlyUserMotorcycles = dbOnlyUserMotorcycles
                .OrderBy(x => x.Year).ToList();

            Assert.Equal(serviceOnlyUserMotorcycles.FirstOrDefault().Title, dbOnlyUserMotorcycles.FirstOrDefault().Title);


            serviceOnlyUserMotorcycles = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebbbaf2-667f245a3582", "NewestYear");

            dbOnlyUserMotorcycles = dbOnlyUserMotorcycles
                .OrderByDescending(x => x.Year).ToList();


            Assert.Equal(serviceOnlyUserMotorcycles.FirstOrDefault().Title, dbOnlyUserMotorcycles.FirstOrDefault().Title);

            Assert.Equal(dbOnlyUserMotorcycles.Count(), serviceOnlyUserMotorcycles.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserMotorcyclesByFiltersReturnsTheCorrectMotorcyclesForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = Condition.New,
                FuelType = FuelType.Petrol,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                Gearbox = 0,
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinYear = 1900,
                MaxYear = DateTime.Now.Year,
            };

            var motorcyclesCollection = service.GetOnlyUserMotorcycles("e4bf2992-cc46-4ebb-baf2-667f245a3582", filtersInputModel);

            var motorcyclesAvailableInDb = dbContext.MotorcycleOffers.Where(x =>
                x.Condition == Condition.New
                && x.FuelType == FuelType.Petrol
                && x.Price >= 100 && x.UserId == "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            Assert.Equal(motorcyclesCollection.Count(), motorcyclesAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfDeleteMotorcycleOfferRemovesTheOfferFromTheDatabase()
        {
            var dbContext = new AutomobileDbContext();
            var service = new MotorcyclesService(dbContext);

            var dbOffer = dbContext.MotorcycleOffers.FirstOrDefault();
            var offerImages = dbContext.OfferImages.Where(x => x.MotorcycleOfferId == dbOffer.Id);

            var getMotorcycleOfferById = service.GetMotorcycleOfferById(dbOffer.Id);
            service.DeleteMotorcycleOffer(getMotorcycleOfferById);

            Assert.True(dbContext.MotorcycleOffers.Any(x => x.Id == dbOffer.Id) == false);

            //Add removed motorcycle and images so that db remains the same. Set Offer Id = 0 to not override identity for Id in database.
            getMotorcycleOfferById.Id = 0;
            dbContext.MotorcycleOffers.Add(getMotorcycleOfferById);
            dbContext.OfferImages.AddRange(offerImages);
            dbContext.SaveChanges();
        }
    }
}