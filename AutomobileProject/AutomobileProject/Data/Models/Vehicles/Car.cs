using System;
using System.Collections.Generic;

namespace AutomobileProject.Data.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
    }
}
