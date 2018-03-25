using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Stage has 2 constructors and 5 properties for handling instance variables.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Stage.cs
 * version: 1.0
 */
namespace Classes
{
    public class Stage
    {
        // Auto Implemented Properties Stage
        public int StageID { get; set; }
        public int ScenarioID { get; set; }
        public String StageDescription { get; set; }
        public String AudioFilePath { get; set; }
        public String ImageFilePath { get; set; }

        // default constructor Stage
        public Stage()
        {
            this.StageID = 0;
            this.ScenarioID = 0;
            this.StageDescription = "";
            this.AudioFilePath = "";
            this.ImageFilePath = "";
        }

        // parameter constructor Stage
        public Stage(int stageID, int scenarioID, string stageDescription, string audioFilePath, string imageFilePath)
        {
            this.StageID = stageID;
            this.ScenarioID = scenarioID;
            this.StageDescription = stageDescription;
            this.AudioFilePath = audioFilePath;
            this.ImageFilePath = imageFilePath;
        }
    }
}