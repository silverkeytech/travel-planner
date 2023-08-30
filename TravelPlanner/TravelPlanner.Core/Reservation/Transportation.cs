using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Core.Reservation
{
    public class Transportation
    {
        public TransporationType TransporationType { get; set; }
        public int MaxCapacity { get; set; }
        public float Price { get; set; }
    }
    public enum TransporationType
    {
        PrivateSedan, 
        PrivateMinibus, 
        PublicBus
    }
}
