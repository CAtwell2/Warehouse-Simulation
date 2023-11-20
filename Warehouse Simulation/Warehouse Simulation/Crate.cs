using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Simulation
{
    public class Crate
    {
        public string Id { get; private set; }
        public double Price { get; private set; }

        public Crate(string id)
        {
            Id = id;
            Price = GenerateRandomPrice();
        }

        private double GenerateRandomPrice()
        {
            Random rnd = new Random();
            return rnd.NextDouble() * (500 - 50) + 50; // Price between $50 and $500
        }
    }
}

