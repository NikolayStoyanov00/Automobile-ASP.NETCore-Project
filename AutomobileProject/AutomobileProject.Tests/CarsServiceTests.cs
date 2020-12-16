using AutomobileProject.Data.Models;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels.Cars;
using AutomobileProject.ViewModels.Cars.Enums;
using System;
using System.Linq;
using Xunit;

namespace AutomobileProject.Tests
{
    public class CarsServiceTests
    {
        [Fact]
        public void CheckIfCarsForVisualizationAreEqualToCarsInDb()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var carsCollection = service.CarsForVisualization();
            var carsAvailableInDb = dbContext.CarOffers.ToList();

            Assert.True(carsCollection.Count == carsAvailableInDb.Count);
        }

        [Fact]
        public void CheckIfCarsForVisualizationBySortingTypeAreSortedCorrectly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var carsCollection = service.CarsForVisualization("UploadDate");
            var carsAvailableInDb = dbContext.CarOffers.OrderByDescending(x => x.CreatedOn).ToList();

            Assert.Equal(carsCollection.First().Id, carsAvailableInDb.First().Id);

            carsCollection = service.CarsForVisualization("LowestPrice");
            carsAvailableInDb = dbContext.CarOffers.OrderBy(x => x.Price).ToList();

            Assert.Equal(carsCollection.First().Id, carsAvailableInDb.First().Id);

            carsCollection = service.CarsForVisualization("HighestPrice");
            carsAvailableInDb = dbContext.CarOffers.OrderByDescending(x => x.Price).ToList();

            Assert.Equal(carsCollection.First().Id, carsAvailableInDb.First().Id);

            carsCollection = service.CarsForVisualization("OldestYear");
            carsAvailableInDb = dbContext.CarOffers.OrderBy(x => x.Year).ToList();

            Assert.Equal(carsCollection.First().Id, carsAvailableInDb.First().Id);

            carsCollection = service.CarsForVisualization("NewestYear");
            carsAvailableInDb = dbContext.CarOffers.OrderByDescending(x => x.Year).ToList();

            Assert.Equal(carsCollection.First().Id, carsAvailableInDb.First().Id);
        }

        [Fact]
        public void CheckIfCarsForVisualizationByFiltersAreReturningCorrectOffers()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = ViewModels.Cars.Enums.Condition.New,
                FuelType = ViewModels.Cars.Enums.FuelType.Petrol,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                Doors = "All",
                Gearbox = 0,
                SteeringWheelSide = 0,
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinHorsePower = 0,
                MaxHorsePower = 1000,
                MinYear = 1900,
                MaxYear = DateTime.Now.Year,
            };

            var carsCollection = service.CarsForVisualization(filtersInputModel);
            var carsAvailableInDb = dbContext.CarOffers.Where(x =>
                x.Condition == ViewModels.Cars.Enums.Condition.New
                && x.FuelType == ViewModels.Cars.Enums.FuelType.Petrol
                && x.Price >= 100);

            Assert.Equal(carsCollection.Count(), carsAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfGetCarByIdReturnsCorrectCar()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var carFromDb = dbContext.CarOffers.FirstOrDefault();
            var carFromService = service.GetCarById(carFromDb.Id);

            Assert.Equal(carFromDb.Id, carFromService.Id);
        }

        [Fact]
        public void CheckIfChangeCarDetailsActuallyChangesTheDetails()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var carFromDb = dbContext.CarOffers.FirstOrDefault();
            VisualizeCarDetailsViewModel model = new VisualizeCarDetailsViewModel()
            {
                Id = carFromDb.Id,
                Type = "New",
                Make = "Audi",
                Model = "Q7",
                Kilometers = 150,
                FuelType = "Diesel",
                HorsePower = 150,
                EngineSize = 1500,
                Gearbox = "Automatic",
                Price = 5000,
                Doors = "2",
                Color = "black",
                Year = 2000,
                Description = "testt"
            };

            service.ChangeCarDetails(model);
            var priceAfterChangeCarDetails = carFromDb.Price;
            Assert.Equal(priceAfterChangeCarDetails, model.Price);
        }

        [Fact]
        public void CheckIfGetOnlyUserCarsReturnsTheCarsForThatParticularUserOnly()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582");

            var dbOnlyUserCars = dbContext.CarOffers.Where(x => x.UserId == "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            Assert.Equal(dbOnlyUserCars.Count(), serviceOnlyUserCars.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserCarsBySortingReturnsTheCorrectCarsForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", "UploadDate");

            var dbOnlyUserCars = dbContext.CarOffers.Where(x => x.UserId == "e4bf2992-cc46-4ebb-baf2-667f245a3582").OrderByDescending(x => x.CreatedOn).ToList(); 

            if (serviceOnlyUserCars.Count == 0 && dbOnlyUserCars.Count == 0)
            {
                Assert.Equal(serviceOnlyUserCars.Count(), dbOnlyUserCars.Count());
                return;
            }

            Assert.Equal(serviceOnlyUserCars.First().Title, dbOnlyUserCars.First().Title);

            serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", "LowestPrice");

            dbOnlyUserCars = dbOnlyUserCars
                .OrderBy(x => x.Price).ToList();

            Assert.Equal(serviceOnlyUserCars.First().Title, dbOnlyUserCars.First().Title);

            serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", "HighestPrice");

            dbOnlyUserCars = dbOnlyUserCars
                .OrderByDescending(x => x.Price).ToList();

            Assert.Equal(serviceOnlyUserCars.First().Title, dbOnlyUserCars.First().Title);

            serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", "OldestYear");

            dbOnlyUserCars = dbOnlyUserCars
                .OrderBy(x => x.Year).ToList();

            Assert.Equal(serviceOnlyUserCars.First().Title, dbOnlyUserCars.First().Title);

            serviceOnlyUserCars = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", "NewestYear");

            dbOnlyUserCars = dbOnlyUserCars
                .OrderByDescending(x => x.Year).ToList();

            Assert.Equal(serviceOnlyUserCars.First().Title, dbOnlyUserCars.First().Title);

            Assert.Equal(dbOnlyUserCars.Count(), serviceOnlyUserCars.Count());
        }

        [Fact]
        public void CheckIfGetOnlyUserCarsByFiltersReturnsTheCorrectCarsForThatParticularUser()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            FiltersInputModel filtersInputModel = new FiltersInputModel()
            {
                Condition = Condition.New,
                FuelType = FuelType.Petrol,
                MinPrice = 100,
                Make = "All",
                Model = "-- All --",
                Doors = "All",
                Gearbox = 0,
                SteeringWheelSide = 0,
                MaxPrice = 1000000,
                MinKilometers = 0,
                MaxKilometers = 1000000,
                MinHorsePower = 0,
                MaxHorsePower = 1000,
                MinYear = 1900,
                MaxYear = DateTime.Now.Year,
            };

            var carsCollection = service.GetOnlyUserCars("e4bf2992-cc46-4ebb-baf2-667f245a3582", filtersInputModel);
            var carsAvailableInDb = dbContext.CarOffers.Where(x =>
                x.Condition == Condition.New
                && x.FuelType == FuelType.Petrol
                && x.Price >= 100 && x.UserId == "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            Assert.Equal(carsCollection.Count(), carsAvailableInDb.Count());
        }

        [Fact]
        public void CheckIfDeleteCarOfferRemovesTheOfferFromTheDatabase()
        {
            var dbContext = new AutomobileDbContext();
            var service = new CarsService(dbContext);

            var dbOffer = dbContext.CarOffers.FirstOrDefault();
            var offerImages = dbContext.OfferImages.Where(x => x.CarOfferId == dbOffer.Id);

            var getCarOfferById = service.GetCarOfferById(dbOffer.Id);
            service.DeleteCarOffer(getCarOfferById);

            Assert.True(dbContext.CarOffers.Any(x => x.Id == dbOffer.Id) == false);

            //Add removed car and images so that db remains the same. Set Offer Id = 0 to not override identity for Id in database.
            getCarOfferById.Id = 0;
            dbContext.CarOffers.Add(getCarOfferById);
            dbContext.OfferImages.AddRange(offerImages);
            dbContext.SaveChanges();
        }
    }
}