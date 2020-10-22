using AutomobileProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Offer
{
    public class AddOfferViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public AddOfferViewModel(AutomobileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Required]
        [Display(Name = "Title")]
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
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public string Condition { get; set; }

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

        public ICollection<MakeModelDto> MakeModel => dbContext.Cars
            .Select(x => new MakeModelDto
            {
                Make = x.Make,
                Model = x.Model
            })
            .Distinct()
            .ToList();

        public DateTime CreatedOn => DateTime.UtcNow;

        [Required]
        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
