using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Offer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Offer
{
    public class AddCarViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public AddCarViewModel()
        {

        }
        public AddCarViewModel(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.ImageFiles = new HashSet<IFormFile>();
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
        public Condition Condition { get; set; }

        [Required]
        [Display(Name = "Horse power")]
        public int HorsePower { get; set; }

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
        public ICollection<IFormFile> ImageFiles { get; set; }

        public ICollection<MakeModelDto> MakeModel => dbContext?.Cars
            .Select(x => new MakeModelDto
            {
                Make = x.Make,
                Model = x.Model
            })
            .Distinct()
            .ToList();
    }
}
