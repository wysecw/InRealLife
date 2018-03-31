using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class DataBaseHandler
    {
        // CONSTANT storing the connection string
        public const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\IRL_SQL_Database.mdf;Integrated Security=True";

        // create new connection
        SqlConnection conn = new SqlConnection(connectionString);

        public String getScenarioName(int ScenarioId)
        {
            String query = @"SELECT ScenarioName FROM Scenario Where ScenarioId =" + ScenarioId;

            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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
            using (SqlCommand command = new SqlCommand(query, conn))
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