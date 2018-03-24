using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/*
 * This class creates a database connection to an Access database and has various methods to manipulate the database.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: ScenarioDBConnection.cs
 * version: 1.0
 */
namespace DBComm2
{
    public class ScenarioDBConnection
    {
        // method to get database connection
        public static OleDbConnection GetScenarioDBConnection()
        {
            // create and instantiate new connection with a connection string
            OleDbConnection connection = new OleDbConnection
            {
                ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\beve_\source\repos\InRealLife\IRL_ScenarioBuilder\IRL_ScenarioBuilder\ScenarioData.accdb;Jet OLEDB:Database Password=password"
            };

            // return connection
            return connection;
        }

        // method to get current scenarios that returns an array list of values
        public static ArrayList GetScenarios()
        {
            // create new array list
            ArrayList scenarioList = new ArrayList();

            // connect database
            OleDbConnection dbConnectToGetScenarios = ScenarioDBConnection.GetScenarioDBConnection();

            // create query string
            string selectScenarioName = "SELECT ScenarioName FROM Scenario";

            // create OleDb command using query string and connection
            OleDbCommand ScenarioCmd = new OleDbCommand(selectScenarioName, dbConnectToGetScenarios);

            // open database
            dbConnectToGetScenarios.Open();

            // create data reader
            OleDbDataReader ScenarioReader = ScenarioCmd.ExecuteReader();

            // while there is data to read, add data to current array list
            while (ScenarioReader.Read())
            {
                scenarioList.Add(ScenarioReader.GetString(0));
            }

            // close connection
            dbConnectToGetScenarios.Close();

            // return array list
            return scenarioList;
        }

        // method to get scenarios
        public static int DeleteSelectedScenario(int lstScenariosSelectedIndex)
        {
            // create return variable for number of rows set to zero
            int scenarioRowsDeleted = 0;

            // connect database
            OleDbConnection dbConnectToDleteSelectedScenario = GetScenarioDBConnection();

            // create DELETE query string
            string deleteEntireScenario = "DELETE * FROM Scenario WHERE ScenarioID = " + lstScenariosSelectedIndex;

            // create OleDb command using DELETION query string and connection
            OleDbCommand Cmd = new OleDbCommand(deleteEntireScenario, dbConnectToDleteSelectedScenario);

            // open database
            dbConnectToDleteSelectedScenario.Open();

            // execute deletion
            scenarioRowsDeleted = Cmd.ExecuteNonQuery();

            // close connection
            dbConnectToDleteSelectedScenario.Close();

            // return number of rows deleted
            return scenarioRowsDeleted;
        }

        //
        //public static DataForRunningScenario()
        //{

        //}
    }
}