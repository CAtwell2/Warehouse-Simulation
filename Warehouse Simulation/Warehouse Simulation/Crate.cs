///////////////////////////////////////////////////////////////////////////////
//
// Author: Caden Atwell, atwellc@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Warehouse Simulation
// Description: Program showing simulation of trucks arriving to a warehouse to see what is 
// most efficient
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Simulation
{
    /// <summary>
    /// Represents a crate in the warehouse simulation.
    /// </summary>
    public class Crate
    {
        /// <summary>
        /// Gets the unique identifier of the crate.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the price value of the crate.
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Crate class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the crate.</param>
        public Crate(string id)
        {
            Id = id;
            Price = GenerateRandomPrice();
        }

        /// <summary>
        /// Generates a random price for the crate between 50 and 500 units.
        /// </summary>
        /// <returns>A double representing the randomly generated price.</returns>
        private double GenerateRandomPrice()
        {
            Random rnd = new Random();
            return rnd.NextDouble() * (500 - 50) + 50;
        }
    }
}
