using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public int CarOfferId { get; set; }
        public CarOffer CarOffer { get; set; }
    }
}
