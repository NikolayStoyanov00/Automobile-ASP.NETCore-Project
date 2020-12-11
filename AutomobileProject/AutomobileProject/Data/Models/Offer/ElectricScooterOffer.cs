using AutomobileProject.Data.Models.User;
using AutomobileProject.ViewModels.Cars.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutomobileProject.Data.Models.Offer
{
    public class ElectricScooterOffer
    {
        public ElectricScooterOffer()
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

        public int? Year { get; set; }

        [Required]
        public Condition Condition { get; set; }

        [Required]
        public int MotorPower { get; set; }

        [Required]
        public int TravellingDistance { get; set; }


        [Required]
        public string Battery { get; set; }

        [Required]
        public int MaxSpeedAchievable { get; set; }

        [Required]
        public int MaxWeight { get; set; }

        public string WaterproofLevel { get; set; }

        [Required]
        public int Kilometers { get; set; }

        [Required]
        public string ScooterSize { get; set; }

        [Required]
        public decimal TiresSize { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public AspNetUsers User { get; set; }
        public string UserId { get; set; }

        [Required]
        public byte[] OfferImage { get; set; }
    }
}
