using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Cars.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Offer
{
    public class AddMotorcycleViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public AddMotorcycleViewModel()
        {

        }
        public AddMotorcycleViewModel(AutomobileDbContext dbContext)
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

        [Required]
        public string Color { get; set; }

        [Required]
        [Range(1800, 2021)]
        [Display(Name = "Year of production")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public Condition Condition { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Required]
        [Display(Name = "Horse power")]
        public int HorsePower { get; set; }

        [Required]
        [Display(Name = "Cubic centimeters")]
        public int CubicCentimeters { get; set; }

        [Required]
        public Gearbox Gearbox { get; set; }

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
