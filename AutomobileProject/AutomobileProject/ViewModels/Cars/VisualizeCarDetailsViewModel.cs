using AutomobileProject.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Offer
{
    public class VisualizeCarDetailsViewModel
    {
        public VisualizeCarDetailsViewModel()
        {
            this.Images = new HashSet<string>();
        }
        public string Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Kilometers { get; set; }

        public string FuelType { get; set; }

        public int HorsePower { get; set; }

        public int EngineSize { get; set; }

        public string Gearbox { get; set; }

        public double Price { get; set; }

        public string Doors { get; set; }

        public string Color { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string MainImage { get; set; }

        public ICollection<string> Images { get; set; }

        public UserViewModel UserDetails { get; set; }
    }
}
