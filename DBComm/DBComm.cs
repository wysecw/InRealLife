using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

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
        // connection string
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\ScenarioData.accdb");

        //
        public String displayScenarioTitle(String scTitle)
        {
            DataSet ds = new DataSet();
            string query = "SELECT ScenarioName FROM Scenario Where ScenarioName = " + scTitle;
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                adapter.Fill(ds);
                return ds.ToString();
            }
        }

        //
        public String displayScenarioDescription(String scTitle)
        {
            DataSet ds = new DataSet();
            String query = "SELECT ScenarioDesc FROM Scenario Where ScenarioName = " + scTitle;
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                adapter.Fill(ds);
                return ds.ToString();
            }

        }

        // to grab all data from scenario table
        public DataTable displayAllScenarios()
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM Scenario";
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                adapter.Fill(dt);
                return dt;
            }
        }

        // to grab all data from scenario table joined to grab relevant data from stage table joined to grab relevant data from answer table
        public DataTable displayRunningScenario()
        {
            DataTable dt = new DataTable();
            String query = "SELECT ScenarioName, StageDescription, AnswerDescription, nextStageID * FROM(Scenario INNER JOIN Stage ON Scenario.[ScenarioID] = Stage.[ScenarioID]) INNER JOIN Answer ON Stage.[StageID] = Answer.[StageID]";
            using (conn)
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                adapter.Fill(dt);
                return dt;
            }
        }

        // method to delete a scenario
        public int DeleteSelectedScenario(int scenarioID)
        {
            // create return variable for number of rows set to zero
            int scenarioRowsDeleted = 0;

            String query = "DELETE * FROM Scenario WHERE ScenarioID = " + scenarioID;
            using (conn)
            using (OleDbCommand Cmd = new OleDbCommand(query, conn))
            {
                scenarioRowsDeleted = Cmd.ExecuteNonQuery();
            }

            // return number of rows deleted
            return scenarioRowsDeleted;
        }
    }
}