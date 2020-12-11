<<<<<<< HEAD
﻿using System;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> f5b16ee745ca8bc92e12e4c5a2194c3b80e6a8a1

namespace AutomobileProject.Data.Models.Vehicles
{
    public class ElectricScooter
    {
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

<<<<<<< HEAD
        public Nullable<int> Year { get; set; }
=======
        public int Year { get; set; }
>>>>>>> f5b16ee745ca8bc92e12e4c5a2194c3b80e6a8a1
    }
}
