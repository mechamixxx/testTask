using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drivee_test { 
    public class Order
    {
        public Location From { get; set; }
        public Location To { get; set; }
        public int Price { get; set; }
        public Order(Location from, Location to, int price)
        {
            From = from;
            To = to;
            Price = price;
        }
    }
}

