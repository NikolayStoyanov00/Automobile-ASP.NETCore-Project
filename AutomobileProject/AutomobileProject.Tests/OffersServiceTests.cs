using AutomobileProject.Data.Models;
using AutomobileProject.Data.Models.Offer;
using AutomobileProject.Services.Offer;
using AutomobileProject.ViewModels.Cars.Enums;
using AutomobileProject.ViewModels.Offer;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace AutomobileProject.Tests
{
    public class OffersServiceTests
    {
        [Fact]
        public void CheckIfAddCarAddsTheCar()
        {
            var dbContext = new AutomobileDbContext();
            var service = new OfferService(dbContext);

            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");

            service.AddCar(new AddCarViewModel()
            {
                Title = "Test",
                Make = "Audi",
                Model = "A3",
                Year = 2003,
                Price = 220,
                Condition = (Condition)Enum.Parse(typeof(Condition), "New"),
                Color = "black",
                SteeringWheelSide = 0,
                FuelType = (FuelType)Enum.Parse(typeof(FuelType), "Diesel"),
                HorsePower = 150,
                EngineSize = 1060,
                Gearbox = (Gearbox)Enum.Parse(typeof(Gearbox), "Automatic"),
                Doors = "2",
                Kilometers = 15000,
                ContactNumber = "03210320232",
                MainImageFile = file
            }, "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            var carOffersContainCar = dbContext.CarOffers.Any(x => x.Title == "Test");

            Assert.True(carOffersContainCar);

            var mockCar = dbContext.CarOffers.FirstOrDefault(x => x.Title == "Test");
            dbContext.CarOffers.Remove(mockCar);
            dbContext.SaveChanges();
        }

        [Fact]
        public void CheckIfAddMotorcycleAddsTheMotorcycle()
        {
            var dbContext = new AutomobileDbContext();
            var service = new OfferService(dbContext);

            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");

            service.AddMotorcycle(new AddMotorcycleViewModel()
            {
                Title = "Test",
                Make = "BMW",
                Model = "HB4",
                Year = 2003,
                Price = 220,
                Condition = (Condition)Enum.Parse(typeof(Condition), "New"),
                Color = "black",
                FuelType = (FuelType)Enum.Parse(typeof(FuelType), "Diesel"),
                HorsePower = 50,
                CubicCentimeters = 650,
                Gearbox = (Gearbox)Enum.Parse(typeof(Gearbox), "Automatic"),
                Kilometers = 15000,
                Description = "asasrsa",
                ContactNumber = "03210320232",
                MainImageFile = file
            }, "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            var motorcycleOffersContainMotorcycle = dbContext.MotorcycleOffers.Any(x => x.Title == "Test");

            Assert.True(motorcycleOffersContainMotorcycle);

            var mockMotorcycle = dbContext.MotorcycleOffers.FirstOrDefault(x => x.Title == "Test");
            dbContext.MotorcycleOffers.Remove(mockMotorcycle);
            dbContext.SaveChanges();
        }

        [Fact]
        public void CheckIfAddElectricScooterAddsTheScooter()
        {
            var dbContext = new AutomobileDbContext();
            var service = new OfferService(dbContext);

            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");

            service.AddElectricScooter(new AddElectricScooterViewModel()
            {
                Title = "Test",
                Make = "Xiaomi",
                Model = "365",
                Year = 2003,
                Price = 220,
                Condition = (Condition)Enum.Parse(typeof(Condition), "New"),
                WaterproofLevel = "test",
                MaxSpeedAchievable = 25,
                MotorPower = 250,
                ScooterSize = "2413",
                TiresSize = 8.5m,
                TravellingDistance = 205,
                Battery = "test",
                Kilometers = 15000,
                Description = "asasrsa",
                ContactNumber = "03210320232",
                MainImageFile = file
            }, "e4bf2992-cc46-4ebb-baf2-667f245a3582");

            var scooterOffersContainScooter = dbContext.ElectricScooterOffers.Any(x => x.Title == "Test");

            Assert.True(scooterOffersContainScooter);

            var mockScooter = dbContext.ElectricScooterOffers.FirstOrDefault(x => x.Title == "Test");
            dbContext.ElectricScooterOffers.Remove(mockScooter);
            dbContext.SaveChanges();
        }
    }
}