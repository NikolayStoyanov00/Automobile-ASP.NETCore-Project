using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Offer;
using AutomobileProject.ViewModels.User;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileProject.ViewModels.ElectricScooters
{
    public class VisualizeScooterDetailsViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public VisualizeScooterDetailsViewModel()
        {
            Images = new HashSet<string>();
            dbContext = new AutomobileDbContext();
        }

        public int Id { get; set; }

        public string Condition { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Kilometers { get; set; }

        public int MotorPower { get; set; }

        public int TravellingDistance { get; set; }

        public int MaxSpeedAchievable { get; set; }

        public decimal TiresSize { get; set; }

        public string WaterproofLevel { get; set; }

        public int MaxWeight { get; set; }

        public double Price { get; set; }

        public string Battery { get; set; }

        public string ScooterSize { get; set; }

        public int? Year { get; set; }

        public string Description { get; set; }

        public string MainImage { get; set; }

        public ICollection<string> Images { get; set; }

        public UserViewModel UserDetails { get; set; }

        public ICollection<MakeModelDto> MakeModel => dbContext?.ElectricScooters
           .Select(x => new MakeModelDto
           {
               Make = x.Make,
               Model = x.Model
           })
           .Distinct()
           .ToList();
    }
}
