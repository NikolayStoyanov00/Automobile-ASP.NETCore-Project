using AutomobileProject.Data.Models.User;
using AutomobileProject.ViewModels.Cars.Enums;
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
        public Condition Condition { get; set; }

        [Required]
        public SteeringWheelSide SteeringWheelSide { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public int HorsePower { get; set; }

        [Required]
        public int EngineSize { get; set; }

        [Required]
        public Gearbox Gearbox { get; set; }

        [Required]
        public string Doors { get; set; }

        [Required]
        public int Kilometers { get; set; }

        public string Description { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public AspNetUsers User { get; set; }
        public string UserId { get; set; }

        [Required]
        public byte[] OfferImage { get; set; }
    }
}
