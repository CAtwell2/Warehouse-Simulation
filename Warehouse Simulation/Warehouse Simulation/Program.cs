using System;
using Warehouse_Simulation;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Warehouse Simulation");

        // Optionally, get user input for the number of docks and time increments
        Console.Write("Enter the number of docks: ");
        int numberOfDocks = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of time increments for the simulation: ");
        int timeIncrements = int.Parse(Console.ReadLine());

        // Create an instance of the Warehouse class
        Warehouse warehouse = new Warehouse(numberOfDocks);

        // Run the simulation
        warehouse.Run(timeIncrements);

        // At this point, the simulation has run and the report has been generated
        Console.WriteLine("Simulation complete. Check the generated report in your downloads folder for details.");
    }
}
