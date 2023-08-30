using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Core.Activity;

namespace TravelPlanner.Core.Place
{
    public class Place
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string TimeToSpend { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
