using System.ComponentModel.DataAnnotations;

namespace AutomobileProject.Data.Models.Vehicles
{
    public class ElectricScooter
    {
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
    }
}
