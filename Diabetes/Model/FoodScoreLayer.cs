using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mars.Components.Layers;
using Mars.Core.Data;
using Mars.Interfaces.Data;
using Mars.Interfaces.Layers;

namespace Diabetes.Model;

public class FoodScoreLayer : AbstractLayer 
{
    #region Init

    /// <summary>
    ///     The initialization method of the FoodScoreLayer which spawns and stores the specified number of each agent type
    /// </summary>
    /// <param name="layerInitData"> Initialization data that is passed to an agent manager which spawns the specified
    /// number of each agent type</param>
    /// <param name="registerAgentHandle">A handle for registering agents</param>
    /// <param name="unregisterAgentHandle">A handle for unregistering agents</param>
    /// <returns>A boolean that states if initialization was successful</returns>
    public override bool InitLayer(LayerInitData layerInitData, RegisterAgent registerAgentHandle,
        UnregisterAgent unregisterAgentHandle)
    {
        var initLayer = base.InitLayer(layerInitData, registerAgentHandle, unregisterAgentHandle);
        
        var agentManager = layerInitData.Container.Resolve<IAgentManager>();

        Patients = agentManager.Spawn<Patient, FoodScoreLayer>().ToList();
        
        Healthy = new List<(string, int)>
        {
            ("Raspberries", 10),
            ("VegCurry", 9),
            ("Tuna", 7 ),
            ("BlackCoffee", 7),
            ("VegSoup", 9),
            ("Almonds", 9)
        };
        
        Medium = new List<(string, int)>
        {
            ("SweetPotChips", 7),
            ("Chicken", 6),
            ("PoultryBurger", 5 ),
            ("PB", 6),
            ("CheeseToast", 3 ),
            ("Biltong", 7 )
        };
        
        Unhealthy = new List<(string, int)>
        {
            ("Pizza", 3),
            ("Cereal", 2),
            ("Cheeseburger", 1 ),
            ("Noodles", 0),
            ("Dessert", 0),
            ("Coke", 0)
        };
        
        return initLayer;
    }

    #endregion

    #region Methods
    
    #endregion

    #region Fields and Properties
    
    public List<(string, int)> Healthy { get; set; }

    public List<(string, int)> Medium { get; set; }
    
    public List<(string, int)> Unhealthy { get; set; }
    public List<Patient> Patients { get; private set; }

    #endregion
}