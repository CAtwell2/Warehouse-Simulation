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
using Warehouse_Simulation;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Warehouse Simulation");

       
        Console.Write("Enter the number of docks: ");
        int numberOfDocks = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of time increments for the simulation: ");
        int timeIncrements = int.Parse(Console.ReadLine());

        
        Warehouse warehouse = new Warehouse(numberOfDocks);

        
        warehouse.Run(timeIncrements);

        
        Console.WriteLine("Simulation complete. Check the generated report in your downloads folder for details.");
    }
}
