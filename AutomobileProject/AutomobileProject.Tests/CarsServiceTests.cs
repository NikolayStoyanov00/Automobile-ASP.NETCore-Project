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
                MinPrice = 100
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
    }
}