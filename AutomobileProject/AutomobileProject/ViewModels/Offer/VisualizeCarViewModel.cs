using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.ViewModels.Offer
{
    public class VisualizeCarViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int HorsePower { get; set; }

        public int EngineSize { get; set; }

        public string Gearbox { get; set; }

        public string Doors { get; set; }

        public string FuelType { get; set; }

        public int Year { get; set; }

        public string Condition { get; set; }

        public double Price { get; set; }

        public int Kilometers { get; set; }

        public string Image { get; set; }
    }
}
