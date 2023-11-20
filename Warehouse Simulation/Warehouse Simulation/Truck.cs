using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Simulation
{
    public class Truck
    {
        public string Driver { get; private set; }
        public string DeliveryCompany { get; private set; }
        private Stack<Crate> Trailer;

        public Truck(string driver, string deliveryCompany)
        {
            Driver = driver;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
        }

        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        public Crate Unload()
        {
            return Trailer.Count > 0 ? Trailer.Pop() : null;
        }

        public bool IsEmpty()
        {
            return Trailer.Count == 0;
        }
    }
}
