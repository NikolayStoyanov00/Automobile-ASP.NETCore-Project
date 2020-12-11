using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.ElectricScooters;
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
            throw new NotImplementedException();
        }

        private string ConvertByteArrayToImage(byte[] arrayImage)
        {
            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;
        }
    }
}
