using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drivee_test
{
    public class Courier
    {
        public Location Location { get; set; }
        //Булевое значение которое показывает есть ли у него заказ
        public bool Order{ get; set; }
        public Courier(Location location, bool order = false)
        {
            Location = location;
            Order = order;
        }
    }
}
