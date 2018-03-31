using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using Classes;
using System.Collections;

/*
 * This class creates a database connection to an Access database and has various methods 
 * to retrieve information or manipulate the database.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: DBComm.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    public class DBComm
    {
        // CONSTANT storing the connection string
        public const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\ScenarioData.accdb";

        // create new connection
        OleDbConnection conn = new OleDbConnection(connectionString);

        // method to grab all data from scenario table on the database
        public DataTable displayAllScenarios()
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM Scenario";
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                adapter.Fill(dt);
                return dt;
            }
        }

        // method to delete a scenario from scenario table on the database
        public int DeleteSelectedScenario(int scenarioID)
        {
            int scenarioRowsDeleted = 0;

            // set query string
            String deleteQuery = "DELETE * FROM Scenario WHERE ScenarioID =" + scenarioID;
            
            using (conn)
            using (OleDbCommand DeleteCmd = new OleDbCommand(deleteQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                // open connection
                conn.Open();

                // execute deletion
                scenarioRowsDeleted = DeleteCmd.ExecuteNonQuery();

                // return number of rows deleted
                return scenarioRowsDeleted;
            }
        }

        public String getScenarioName(int ScenarioId)
        {
            String query = @"SELECT ScenarioName FROM Scenario Where ScenarioId =" + ScenarioId;

            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                return "" + result;
            }


        }

        public String getAnswer(int AnswerId, int StageID)
        {
            String query = "SELECT AnswerDescription FROM Answer WHERE StageID = " + StageID + " AND AnswerID = " + AnswerId;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                return "" + result;
            }
        }

        public int getNextStageID(int AnswerId, int StageID)
        {
            String query = "SELECT nextStageID FROM Answer WHERE StageID = " + StageID + " AND AnswerID = " + AnswerId;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public int getStageID(int ScenarioID, int stage)
        {
            String query = "SELECT StageID FROM Stage WHERE ScenarioID = " + ScenarioID + " and stage = " + stage;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public String getAudioFilePath(int StageID)
        {
            String query = "SELECT AudioFilePath FROM Stage WHERE StageID = " + StageID;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public String getStageDescription(int StageID)
        {
            String query = "SELECT StageDescription FROM Stage WHERE StageID = " + StageID;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public String getImageFilePath(int StageID)
        {
            String query = "SELECT ImageFilePath FROM Stage WHERE StageID = " + StageID;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public int getAnswerID(int StageID, int answerNum)
        {
            String query = "SELECT AnswerID FROM Answer WHERE StageID = " + StageID + " AND Answer = " + answerNum;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public String getAnswerDescription(int AnswerID)
        {
            String query = "SELECT AnswerDescription FROM answer WHERE AnswerID = " + AnswerID;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public int getNextStageID(int AnswerID)
        {
            String query = "SELECT nextStageID FROM Answer WHERE AnswerID = " + AnswerID;
            using (conn)
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }
    }
}