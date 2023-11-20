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
    /// Represents a truck in the warehouse simulation.
    /// </summary>
    public class Truck
    {
        /// <summary>
        /// Gets the name of the driver of the truck.
        /// </summary>
        public string Driver { get; private set; }

        /// <summary>
        /// Gets the name of the delivery company associated with this truck.
        /// </summary>
        public string DeliveryCompany { get; private set; }

        // Stack representing the trailer of the truck, loaded with crates.
        private Stack<Crate> Trailer;

        /// <summary>
        /// Initializes a new instance of the Truck class with specified driver and delivery company.
        /// </summary>
        /// <param name="driver">The name of the driver.</param>
        /// <param name="deliveryCompany">The name of the delivery company.</param>
        public Truck(string driver, string deliveryCompany)
        {
            Driver = driver;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
        }

        /// <summary>
        /// Loads a crate onto the truck.
        /// </summary>
        /// <param name="crate">The crate to load onto the truck.</param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        /// <summary>
        /// Unloads a crate from the truck.
        /// </summary>
        /// <returns>The unloaded crate, if any; otherwise, null.</returns>
        public Crate Unload()
        {
            return Trailer.Count > 0 ? Trailer.Pop() : null;
        }

        /// <summary>
        /// Determines whether the truck's trailer is empty.
        /// </summary>
        /// <returns>true if the trailer is empty; otherwise, false.</returns>
        public bool IsEmpty()
        {
            return Trailer.Count == 0;
        }
    }
}

