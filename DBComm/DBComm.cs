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
        public const string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\ScenarioData.accdb";

        // create new connection
        OleDbConnection conn = new OleDbConnection(connectionString);

        // method to grab the scenario title
        public String displayScenarioTitle(String scTitle)
        {
            DataSet ds = new DataSet();
            string query = "SELECT ScenarioName FROM Scenario Where ScenarioName = " + scTitle;
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                adapter.Fill(ds);
                return ds.ToString();
            }
        }

        // method to grab scenario description
        public String displayScenarioDescription(String scTitle)
        {
            DataSet ds = new DataSet();
            String query = "SELECT ScenarioDesc FROM Scenario Where ScenarioName = " + scTitle;
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                adapter.Fill(ds);
                return ds.ToString();
            }
        }

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

        /*
         * method to grab data from scenario table
         * joined to grab relevant data from stage table 
         * joined to grab relevant data from answer table
        */    
        public DataTable displayRunningScenario()
        {
            DataTable dt = new DataTable();

            // set query string
            String query = "SELECT ScenarioName, StageDescription, AnswerDescription, nextStageID * FROM(Scenario INNER JOIN Stage ON Scenario.[ScenarioID] = Stage.[ScenarioID]) INNER JOIN Answer ON Stage.[StageID] = Answer.[StageID]";

            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                // open connection
                conn.Open();

                // use adapter to fill data table
                adapter.Fill(dt);

                // return data table
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
    }
}