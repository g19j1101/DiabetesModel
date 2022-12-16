using System;
using System.Linq;
using System.Collections.Generic;
using Mars.Interfaces;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Annotations;

namespace Diabetes.Model;

public class Patient : IAgent<FoodScoreLayer>
{
    #region Init

    /// <summary>
    ///     The initialization method of the Patient which is executed once at the beginning of a simulation.
    /// </summary>
    /// <param name="layer">The FoodScoreLayer that manages the agent</param>
    public void Init(FoodScoreLayer layer)
    {
        _layer = layer;
        MealScore = 0;
        Age = 18;
        Context = _layer.Context;
        if (Childhood > 7 && BMI == "normal" && Family_History == false && Type1 == false)
            HealthScore = _random.Next(7, 10);
        else
            HealthScore = _random.Next(0, 6);
    }

    #endregion

    #region Tick

    /// <summary>
    ///     The tick method of the Patient which is executed during each time step of the simulation.
    ///     A Patient can move randomly along diagonal lines. It must stay within the bounds of the FoodScoreLayer
    ///     and cannot move onto grid cells that are not routable.
    /// </summary>
    public void Tick()
    {
        //Each tick is a 24 hour cycle that consists of the total macronutrients eaten by the patient
        //There will be 15695 ticks over 43 years (18 to 60)
        //The macronutrients are made up of carbohydrates, fats and proteins
        //amount meals
        //diet == meals 
        //increment health score 
        //at the end, output the average score -> showing accumaltaion of diet
        var date = (DateTime) Context.CurrentTimePoint; 
        Month = date.Month;
        Day = date.Day;
        Year = date.Year;
        int lifestyle;
        if (Month == 12 && Day == 31)
            Age++;
        
        int meals = _random.Next(2,7);
        
        if (Diet == "healthy")
        {
            menu = _layer.Healthy;
            Eat(menu, meals);
        }
        else if (Diet == "medium")
        {
            menu = _layer.Medium;
            Eat(menu, meals);
        }
        else
        {
            menu = _layer.Unhealthy;
            Eat(menu, meals);
        }

        if (Year == 2061)
        {
            int total = 365 * 43;
            HealthScore = HealthScore / total; //max score possible for three most healthy meals a day == 30
            Console.WriteLine("Final Score for Patient " + PatientID + ": " + HealthScore);
        }
        //TO DO: randomise choice of changing diet 
        //More complex --> descion-making behaviour
        lifestyle = _random.Next(0, 2);
        if (lifestyle == 1)
            ChangeDiet(); //patient does undergo a lifestyle change 
    }

    #endregion

    #region Methods

    public void Eat(List<(string, int)> menu, int meals)
    {
        int meal; 
        
        while(meals > 0)
        {
            meal = _random.Next(6);
            (string Food, int Score) item = menu.ElementAt(meal); 
            MealScore += item.Score; 
            Console.WriteLine("Patient " + PatientID + " is eating " + item.Food);
            meals--;  
        }
        HealthScore += MealScore;
        MealScore = 0; //reset for next day
    }

    public void ChangeDiet()
    {
        int choice = _random.Next(3);
        if (choice == 0)
            Diet = "healthy";
        else if (choice == 1)
            Diet = "medium";
        else
            Diet = "unhealthy";
        Console.WriteLine("Patient " + PatientID + " Diet is now " + Diet);
    } //too simple and random
    #endregion

    #region Fields and Properties
    [PropertyDescription]
    public int PatientID { get; set; }

    [PropertyDescription]
    public int Childhood { get; set; }
    
    [PropertyDescription]
    public bool Family_History { get; set; }
    
    [PropertyDescription]
    public string BMI { get; set; }
    
    [PropertyDescription]
    public bool Type1 { get; set; }
    
    [PropertyDescription] 
    public string Diet { get; set; }
    
    public int HealthScore { get; set; }
    
    private List<(string, int)> menu;

    public int MealScore;

    public int Age;
    
    private int Year, Month, Day; 

    private FoodScoreLayer _layer;

    private ISimulationContext Context;

    public Guid ID { get; set; }
   
    private readonly Random _random = new();

    #endregion
}