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
    public class Dock
    {
        public string Id { get; private set; }
        private Queue<Truck> Line;
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TotalTrucks { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse { get; private set; }

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
        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
            TotalTrucks++;
        }
        public bool IsLineEmpty()
        {
            return Line.Count == 0;
        }
        public Truck SendOff()
        {
            return Line.Count > 0 ? Line.Dequeue() : null;
        }

        public void ProcessTruck(Warehouse warehouseInstance)
        {
            if (Line.Count > 0)
            {
                Truck currentTruck = Line.Peek();
                Crate crate = currentTruck.Unload();
                if (crate != null)
                {
                    
                    string scenario = DetermineUnloadingScenario(currentTruck, warehouseInstance);

                  
                    warehouseInstance.LogCrateUnloading(crate, currentTruck, scenario);

                    TotalSales += crate.Price;
                    TotalCrates++;
                    TimeInUse++;
                }

                if (currentTruck.IsEmpty())
                {
                    SendOff();
                }
            }
            else
            {
                TimeNotInUse++;
            }
        }

        private string DetermineUnloadingScenario(Truck truck, Warehouse warehouseInstance)
        {
            if (!truck.IsEmpty())
            {
                return "A crate was unloaded, but the truck still has more crates to unload";
            }
            else if (Line.Count > 1 || (Line.Count == 1 && warehouseInstance.Entrance.Count > 0))
            {
                return "A crate was unloaded, and the truck has no more crates to unload, and another truck is already in the Dock";
            }
            else
            {
                return "A crate was unloaded, and the truck has no more crates to unload, but another truck is NOT already in the Dock";
            }
        
    }
   }
}
