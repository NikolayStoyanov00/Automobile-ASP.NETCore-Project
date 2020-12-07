using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Cars.Enums;
using AutomobileProject.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Motorcycles
{
    public class FiltersInputModel
    {
        private readonly AutomobileDbContext dbContext;

        public FiltersInputModel()
        {
            dbContext = new AutomobileDbContext();
        }

        public Condition Condition { get; set; }

        [Display(Name = "Fuel type:")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Gearbox:")]
        public Gearbox Gearbox { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [Display(Name = "Steering wheel side:")]
        public SteeringWheelSide SteeringWheelSide { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public int MinKilometers { get; set; }
        public int MaxKilometers { get; set; }

        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        public string Color { get; set; }

        public ICollection<MakeModelDto> MakeModel => dbContext?.Motorcycles
            .Select(x => new MakeModelDto
            {
                Make = x.Make,
                Model = x.Model
            })
            .Distinct()
            .ToList();
    }
}
