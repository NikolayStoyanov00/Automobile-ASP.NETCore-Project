using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Cars.Enums;
using AutomobileProject.ViewModels.Offer;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileProject.ViewModels.ElectricScooters
{
    public class FiltersInputModel
    {
        private readonly AutomobileDbContext dbContext;

        public FiltersInputModel()
        {
            dbContext = new AutomobileDbContext();
        }

        public Condition Condition { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public int MinKilometers { get; set; }
        public int MaxKilometers { get; set; }

        public int MinMotorPower { get; set; }
        public int MaxMotorPower { get; set; }

        public ICollection<MakeModelDto> MakeModel => dbContext?.ElectricScooterOffers
            .Select(x => new MakeModelDto
            {
                Make = x.Make,
                Model = x.Model
            })
            .Distinct()
            .ToList();
    }
}
