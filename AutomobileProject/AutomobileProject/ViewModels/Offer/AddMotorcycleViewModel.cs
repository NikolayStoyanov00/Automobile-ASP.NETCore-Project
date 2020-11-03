using AutomobileProject.Data.Models;
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
        [Range(1800, 2021)]
        [Display(Name = "Year of production")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public string Condition { get; set; }

        [Display(Name = "Horse power")]
        public int HorsePower { get; set; }

        [Display(Name = "Cubic centimeters")]
        public int CubicCentimeters { get; set; }

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
        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "More Images")]
        public ICollection<IFormFile> MoreImageFiles { get; set; }


        public ICollection<MakeModelDto> MakeModel => dbContext.Motorcycles
            .Select(x => new MakeModelDto
            {
                Make = x.Make,
                Model = x.Model
            })
            .Distinct()
            .ToList();
    }
}
