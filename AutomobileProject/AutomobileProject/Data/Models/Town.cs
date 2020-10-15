using System;
using System.Collections.Generic;

namespace AutomobileProject.Data.Models
{
    public partial class Town
    {
        public int Id { get; set; }
        public string NameBg { get; set; }
        public string NameEn { get; set; }
        public int Population { get; set; }
    }
}
