# Diabetes Prototype Model

This model attempts to represent the effect of diet on a person's chance of becoming diabetic. Overall, the final HealthScore should be interpreted as follows:
 - Close to 0: likely to be diabetic.
 - Close to 30: unlikely to be diabetic. 

## Project structure

Below is a brief description of each component of the project structure:

- `Program.cs`: the entry point of the model from which the model can be started. See [Model setup and execution](#model-setup-and-execution) below for more details.
- `config.json`: a JavaScript Object Notation (JSON) with which the model can be configured. See [Model configuration](#model-configuration) below for more details.
- `Model`: a directory that holds the agent types, layer types, entity types, and other classes of the model. See [Model description](#model-description) for more details.
- `Resources`: a directory that holds the external resources of the model that are integrated into the model at runtime. This includes initialization and parameterization files for agent types and layer types.

## Model description

The model consists of the following agent types and layer types:

- Agent types:
  - `Patient`: an agent that eats healthy, medium healthy or unhealthy meals.
- Layer types:
  - `FoodScoreLayer`: a layer that the patient exists on and where menus are intialised.
## Model configuration

The model can be configured via a JavaScript Object Notation (JSON) file called `config.json`. Below are some of the main configurable parameters:

- `startTime` and `endTime`: the start time and end time, respectively, of the simulation
- `deltaT`: the length of a single time step. The simulation time is given by the number of `deltaT` time steps that fit into the range defined by `startTime` and `endTime`
- `layers`: the layer types that should be included in the simulation
- `agents`: the agent types that should be included in the simulation. By default, five instances of the `Patient` agent are run. They have varying data corresponding to healthy, medium and unhealthy history. 

For more detailed information on configuration parameters, please view the MARS documentation [here](https://mars.haw-hamburg.de/articles/core/model-configuration/index.html).

## Model setup and execution

The following tools are required on your machine to run a full simulation of this model:

- A C# Interactive Development Environment (IDE), or any other text editer. 
- [.NET Core](https://dotnet.microsoft.com/en-us/download) 6.0 or higher

To set up and run the simulation, please follow these steps:

1. Open a terminal.
2. Navigate into the Diabetes/Diabetes folder.
3. Type the command: 'dotnet run -project Diabetes.csproj'
4. Press enter. 

OR

1. Run the project in your preferred editor. 

