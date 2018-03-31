using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Answer has 2 constructors and 4 properties for handling instance variables.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Answer.cs
 * version: 1.0
 */
namespace Classes
{
    public class Answer
    {
        // Auto Implemented Properties Answer
        public int AnswerID { get; set; }
        public int StageID { get; set; }
        public String AnswerDescription { get; set; }
        public int NextStageID { get; set; }

        // default constructor Answer
        public Answer()
        {
            this.AnswerID = 0;
            this.StageID = 0;
            this.AnswerDescription = "";
            this.NextStageID = 0;
        }

        // parameter constructor Answer
        public Answer(int answerID, int stageID, string answerDescription, int nextStageID)
        {
            this.AnswerID = answerID;
            this.StageID = stageID;
            this.AnswerDescription = answerDescription;
            this.NextStageID = nextStageID;
        }
    }
}