using System;
using System.IO;
using Mars.Components.Starter;
using Mars.Interfaces.Model;

namespace Diabetes.Model;

internal static class Program
{
    private static void Main()
    {
        // Create a new model description and add model components to it
        var description = new ModelDescription();
        description.AddLayer<FoodScoreLayer>();
        description.AddAgent<Patient, FoodScoreLayer>();

        // Load the simulation configuration from a JSON configuration file
        var file = File.ReadAllText("config.json");
        var config = SimulationConfig.Deserialize(file);

        // Couple model description and simulation configuration
        var starter = SimulationStarter.Start(description, config);

        // Run the simulation
        var handle = starter.Run();
        
        // Close the program
        Console.WriteLine("Successfully executed iterations: " + handle.Iterations);
        starter.Dispose();
    }
}