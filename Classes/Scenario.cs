using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Scenario has 2 constructors and 2 properties for handling instance variables.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Scenario.cs
 * version: 1.0
 */
namespace Classes
{
    public class Scenario
    {
        // Auto Implemented Properties Scenario
        public int ScenarioID { get; set; }
        public string ScenarioName { get; set; }

        // default constructor Scenario
        public Scenario()
        {
            this.ScenarioID = 0;
            this.ScenarioName = "";
        }

        // parameter constructor Scenario
        public Scenario(int scenarioID, string scenarioName)
        {
            this.ScenarioID = scenarioID;
            this.ScenarioName = scenarioName;
        }
    }
}