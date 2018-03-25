using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DataHandler
    {
        public Scenario scenario = new Scenario();
        public Stage stage = new Stage();
        public Answer answer1 = new Answer();
        public Answer answer2 = new Answer();


        public void Intetialize(int scenarioNum)
        {
            DataBaseHandler Dbase = new DataBaseHandler();
            scenario.ScenarioID = scenarioNum;
            scenario.ScenarioName = Dbase.getScenarioName(scenario.ScenarioID);

            stage.ScenarioID = scenario.ScenarioID;
            stage.StageID = Dbase.getStageID(stage.ScenarioID, 1);
            stage.AudioFilePath = Dbase.getAudioFilePath(stage.StageID);
            stage.StageDescription = Dbase.getStageDescription(stage.StageID);
            stage.ImageFilePath = Dbase.getImageFilePath(stage.StageID);


            answer1.StageID = stage.StageID;
            answer1.AnswerID = Dbase.getAnswerID(answer1.StageID, 1);
            answer1.AnswerDescription = Dbase.getAnswerDescription(answer1.AnswerID);
            answer1.NextStageID = Dbase.getNextStageID(answer1.AnswerID);

            answer2.StageID = stage.StageID;
            answer2.AnswerID = Dbase.getAnswerID(answer2.StageID, 2);
            answer2.AnswerDescription = Dbase.getAnswerDescription(answer2.AnswerID);
            answer2.NextStageID = Dbase.getNextStageID(answer2.AnswerID);
        }

        public void Update(int AnswerNumber)
        {
            DataBaseHandler Dbase = new DataBaseHandler();
            if (AnswerNumber == 1)
            {
                    stage.StageID = Dbase.getStageID(scenario.ScenarioID, answer1.NextStageID);
                    stage.AudioFilePath = Dbase.getAudioFilePath(stage.StageID);
                    stage.StageDescription = Dbase.getStageDescription(stage.StageID);
                    stage.ImageFilePath = Dbase.getImageFilePath(stage.StageID);


                    answer1.StageID = stage.StageID;
                    answer1.AnswerID = Dbase.getAnswerID(answer1.StageID, 1);
                    answer1.AnswerDescription = Dbase.getAnswerDescription(answer1.AnswerID);
                    answer1.NextStageID = Dbase.getNextStageID(answer1.AnswerID);

                    answer2.StageID = stage.StageID;
                    answer2.AnswerID = Dbase.getAnswerID(answer2.StageID, 2);
                    answer2.AnswerDescription = Dbase.getAnswerDescription(answer2.AnswerID);
                    answer2.NextStageID = Dbase.getNextStageID(answer2.AnswerID);

            }
            else if (AnswerNumber == 2)
            {

                    stage.StageID = Dbase.getStageID(stage.ScenarioID, answer2.NextStageID);
                    stage.AudioFilePath = Dbase.getAudioFilePath(stage.StageID);
                    stage.StageDescription = Dbase.getStageDescription(stage.StageID);
                    stage.ImageFilePath = Dbase.getImageFilePath(stage.StageID);


                    answer1.StageID = stage.StageID;
                    answer1.AnswerID = Dbase.getAnswerID(answer1.StageID, 1);
                    answer1.AnswerDescription = Dbase.getAnswerDescription(answer1.AnswerID);
                    answer1.NextStageID = Dbase.getNextStageID(answer1.AnswerID);

                    answer2.StageID = stage.StageID;
                    answer2.AnswerID = Dbase.getAnswerID(answer2.StageID, 2);
                    answer2.AnswerDescription = Dbase.getAnswerDescription(answer2.AnswerID);
                    answer2.NextStageID = Dbase.getNextStageID(answer2.AnswerID);
            }
        }
    }
}
