using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Data.Models.Offer
{
    public class CarOffer
    {
        public CarOffer()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]

        public string Title { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Condition { get; set; }

        public int HorsePower { get; set; }

        public int Kilometers { get; set; }

        public string Description { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public byte[] ImageFile { get; set; }
    }
}
