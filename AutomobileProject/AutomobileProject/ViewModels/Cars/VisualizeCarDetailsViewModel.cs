﻿using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Offer;
using AutomobileProject.ViewModels.User;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileProject.ViewModels.Cars
{
    public class VisualizeCarDetailsViewModel
    {
        private readonly AutomobileDbContext dbContext;

        public VisualizeCarDetailsViewModel()
        {
            Images = new HashSet<string>();
            dbContext = new AutomobileDbContext();
        }

        public int Id { get; set; }

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
