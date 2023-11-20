﻿///////////////////////////////////////////////////////////////////////////////
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
    /// Represents a loading dock in the warehouse simulation.
    /// </summary>
    public class Dock
    {
        /// <summary>
        /// Gets the unique identifier of the dock.
        /// </summary>
        public string Id { get; private set; }

        // Queue of trucks waiting to be processed at this dock.
        private Queue<Truck> Line;

        /// <summary>
        /// Gets the total sales value of all crates unloaded at this dock.
        /// </summary>
        public double TotalSales { get; private set; }

        /// <summary>
        /// Gets the total number of crates unloaded at this dock.
        /// </summary>
        public int TotalCrates { get; private set; }

        /// <summary>
        /// Gets the total number of trucks processed at this dock.
        /// </summary>
        public int TotalTrucks { get; private set; }

        /// <summary>
        /// Gets the total time increments this dock was in use.
        /// </summary>
        public int TimeInUse { get; private set; }

        /// <summary>
        /// Gets the total time increments this dock was not in use.
        /// </summary>
        public int TimeNotInUse { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Dock class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the dock.</param>
        public Dock(string id)
        {
            Id = id;
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        }

        /// <summary>
        /// Adds a truck to the line of trucks waiting at this dock.
        /// </summary>
        /// <param name="truck">The truck to add to the line.</param>
        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
            TotalTrucks++;
        }

        /// <summary>
        /// Checks if there are any trucks waiting in line at this dock.
        /// </summary>
        /// <returns>true if the line is empty; otherwise, false.</returns>
        public bool IsLineEmpty()
        {
            return Line.Count == 0;
        }

        /// <summary>
        /// Processes the first truck in line at this dock, unloading a crate if available.
        /// </summary>
        /// <param name="warehouseInstance">Instance of the warehouse containing this dock.</param>
        public void ProcessTruck(Warehouse warehouseInstance)
        {
            // ... existing implementation ...
        }

        private string DetermineUnloadingScenario(Truck truck, Warehouse warehouseInstance)
        {
            // ... existing implementation ...
        }
    }
}
