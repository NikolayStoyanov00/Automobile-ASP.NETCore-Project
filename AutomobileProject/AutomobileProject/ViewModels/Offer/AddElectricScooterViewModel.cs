using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Cars.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AutomobileProject.ViewModels.Offer
{
    public class AddElectricScooterViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public AddElectricScooterViewModel()
        {

        }
        public AddElectricScooterViewModel(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Required]
        [Display(Name = "Offer Title")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Range(1800, 2021)]
        [Display(Name = "Year of production")]
        public int? Year { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public Condition Condition { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Required]
        [Display(Name = "Motor power")]
        public int MotorPower { get; set; }

        [Required]
        [Display(Name = "Waterproof level")]
        public string WaterproofLevel { get; set; }

        [Required]
        [Display(Name = "Travelling distance")]
        public int TravellingDistance { get; set; }

        [Required]
        [Display(Name = "Max speed achievable")]
        public int MaxSpeedAchievable { get; set; }

        [Required]
        [Display(Name = "Max recommended weight")]
        public int MaxWeight { get; set; }

        [Display(Name = "Scooter dimensions")]
        public string ScooterSize { get; set; }

        [Required]
        [Display(Name = "Battery")]
        public string Battery { get; set; }

        [Required]
        [Display(Name = "Tire size")]
        public decimal TiresSize { get; set; }

        [Required]
        [Display(Name = "Kilometers")]
        public int Kilometers { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Contact number")]
        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;

        [Required]
        public IFormFile MainImageFile { get; set; }
        public IFormFile SecondImageFile { get; set; }
        public IFormFile ThirdImageFile { get; set; }
        public IFormFile FourthImageFile { get; set; }
        public IFormFile FifthImageFile { get; set; }
        public IFormFile SixthImageFile { get; set; }

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
