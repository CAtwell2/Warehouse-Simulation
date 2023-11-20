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
    /// Represents the warehouse in the simulation, managing the docks and the process of truck arrivals and departures.
    /// </summary>
    public class Warehouse
    {
        private List<Dock> Docks;
        /// <summary>
        /// Queue of trucks waiting to enter the docks.
        /// </summary>
        public Queue<Truck> Entrance { get; private set; }
        private int CurrentTimeIncrement;
        private StringBuilder logBuilder;

        /// <summary>
        /// Initializes a new instance of the Warehouse class with a specified number of docks.
        /// </summary>
        /// <param name="numberOfDocks">The number of docks to be created in the warehouse.</param>
        public Warehouse(int numberOfDocks)
        {
            Docks = new List<Dock>(numberOfDocks);
            for (int i = 0; i < numberOfDocks; i++)
            {
                Docks.Add(new Dock("Dock" + (i + 1).ToString()));
            }
            Entrance = new Queue<Truck>();
            CurrentTimeIncrement = 0;
            logBuilder = new StringBuilder();
        }

        /// <summary>
        /// Runs the simulation for a specified number of time increments.
        /// </summary>
        /// <param name="totalIncrements">The total number of time increments for the simulation to run.</param>
        public void Run(int totalIncrements)
        {
            for (CurrentTimeIncrement = 0; CurrentTimeIncrement < totalIncrements; CurrentTimeIncrement++)
            {
                HandleTruckArrivals();
                AssignTrucksToDocks();

                foreach (var dock in Docks)
                {
                    dock.ProcessTruck(this);
                }
            }

            GenerateReport();
            WriteLogToFile();
        }

        /// <summary>
        /// Handles the arrival of trucks at the warehouse, simulating random truck arrivals.
        /// </summary>
        private void HandleTruckArrivals()
        {
            Random rnd = new Random();
            int trucksArriving = 0;

           
            double morningArrivalProbability = 0.2; 
            double middayArrivalProbability = 0.5;  
            double eveningArrivalProbability = 0.2; 

          
            if (CurrentTimeIncrement <= 16) 
            {
                trucksArriving = rnd.NextDouble() < morningArrivalProbability ? rnd.Next(1, 4) : 0;
            }
            else if (CurrentTimeIncrement <= 32) 
            {
                trucksArriving = rnd.NextDouble() < middayArrivalProbability ? rnd.Next(1, 6) : 0;
            }
            else 
            {
                trucksArriving = rnd.NextDouble() < eveningArrivalProbability ? rnd.Next(1, 4) : 0;
            }
            for (int i = 0; i < trucksArriving; i++)
            {
                string driver = "Driver" + rnd.Next(1000, 9999);
                string company = "Company" + rnd.Next(1, 10);
                Truck newTruck = new Truck(driver, company);

                int numberOfCrates = rnd.Next(1, 11);
                for (int j = 0; j < numberOfCrates; j++)
                {
                    Crate newCrate = new Crate("Crate" + rnd.Next(10000, 99999));
                    newTruck.Load(newCrate);
                }

                Entrance.Enqueue(newTruck);
            }
        }
        /// <summary>
        /// Assigns arriving trucks to available docks for unloading.
        /// </summary>
        private void AssignTrucksToDocks()
        {
            foreach (var dock in Docks)
            {
                if (dock.IsLineEmpty() && Entrance.Count > 0)
                {
                    Truck truckToAssign = Entrance.Dequeue();
                    dock.JoinLine(truckToAssign);
                }
            }
        }

        /// <summary>
        /// Logs information about each crate as it is unloaded from a truck.
        /// </summary>
        /// <param name="crate">The crate being unloaded.</param>
        /// <param name="truck">The truck from which the crate is being unloaded.</param>
        /// <param name="scenario">The unloading scenario.</param>
        public void LogCrateUnloading(Crate crate, Truck truck, string scenario)
        {
            string csvLine = $"{CurrentTimeIncrement}, {truck.Driver}, {truck.DeliveryCompany}, {crate.Id}, {crate.Price}, {scenario}\n";

          
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\unloading_log.csv";
            File.AppendAllText(filePath, csvLine);
        }
        /// <summary>
        /// Generates a summary report of the warehouse simulation.
        /// </summary>
        private void GenerateReport()
        {
            double totalRevenue = 0;
            int totalCratesUnloaded = 0;
            int totalTrucksProcessed = 0;
            double totalOperatingCost = 0;
            int totalTimeInUse = 0;
            int totalTimeNotInUse = 0;

            foreach (var dock in Docks)
            {
                totalRevenue += dock.TotalSales;
                totalCratesUnloaded += dock.TotalCrates;
                totalTrucksProcessed += dock.TotalTrucks;
                totalTimeInUse += dock.TimeInUse;
                totalTimeNotInUse += dock.TimeNotInUse;
                totalOperatingCost += dock.TimeInUse * 100; 
            }

            double averageValuePerCrate = totalCratesUnloaded > 0 ? totalRevenue / totalCratesUnloaded : 0;
            double averageValuePerTruck = totalTrucksProcessed > 0 ? totalRevenue / totalTrucksProcessed : 0;
            double averageTimeInUsePerDock = Docks.Count > 0 ? (double)totalTimeInUse / Docks.Count : 0;
            double averageTimeNotInUsePerDock = Docks.Count > 0 ? (double)totalTimeNotInUse / Docks.Count : 0;
            double netRevenue = totalRevenue - totalOperatingCost;

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Warehouse Simulation Report");
            reportBuilder.AppendLine($"Total Number of Docks: {Docks.Count}");
            reportBuilder.AppendLine($"Total Revenue: ${totalRevenue}");
            reportBuilder.AppendLine($"Total Operating Cost: ${totalOperatingCost}");
            reportBuilder.AppendLine($"Net Revenue: ${netRevenue}");
            reportBuilder.AppendLine($"Total Crates Unloaded: {totalCratesUnloaded}");
            reportBuilder.AppendLine($"Total Trucks Processed: {totalTrucksProcessed}");
            reportBuilder.AppendLine($"Average Value per Crate: ${averageValuePerCrate}");
            reportBuilder.AppendLine($"Average Value per Truck: ${averageValuePerTruck}");
            reportBuilder.AppendLine($"Average Time In Use Per Dock: {averageTimeInUsePerDock} time increments");
            reportBuilder.AppendLine($"Average Time Not In Use Per Dock: {averageTimeNotInUsePerDock} time increments");

           
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

            
            string reportFilePath = Path.Combine(downloadsPath, "simulation_report.txt");

            
            File.WriteAllText(reportFilePath, reportBuilder.ToString());
        }


        /// <summary>
        /// Writes the accumulated log entries to a file.
        /// </summary>
        private void WriteLogToFile()
        {
            File.WriteAllText("unloading_log.csv", logBuilder.ToString());
        }
    }
}
