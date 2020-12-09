using AutomobileProject.Data.Models.Vehicles;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutomobileProject.Data.Models.Offer
{
    public class OfferImage
    {
        public OfferImage()
        {
            this.ImageId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ImageId { get; set; }
        public byte[] Image { get; set; }

        public Nullable<int> CarOfferId { get; set; }
        public CarOffer CarOffer { get; set; }

        public Nullable<int> MotorcycleOfferId { get; set; }
        public MotorcycleOffer MotorcycleOffer { get; set; }

        public Nullable<int> ElectricScooterOfferId { get; set; }
        public ElectricScooter ElectricScooterOffer { get; set; }
    }
}
