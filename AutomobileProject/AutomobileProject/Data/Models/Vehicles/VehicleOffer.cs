using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Data.Models
{
    public class VehicleOffer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public Byte[] MainImageUpload { get; set; }
    }
}
