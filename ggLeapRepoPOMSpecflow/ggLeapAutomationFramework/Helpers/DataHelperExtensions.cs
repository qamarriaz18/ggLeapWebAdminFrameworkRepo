using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ggLeapAutomationFramework.Helpers
{
    public static class DataHelperExtensions
    {
        //Open the connection
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectinString)
        {
            try 
            {
                sqlConnection = new SqlConnection(connectinString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(Exception e)
            {
                LogHelpers.Write("ERROR Message :: " + e.Message);
            }
            return null;
        }

        //Closing the connection
        public static void DBClose(this SqlConnection sqlConnection)
        {

            try 
            {
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                LogHelpers.Write("ERROR Message :: " + e.Message);
            }
        }

        //Query Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;

            try
            {
                if(sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed || 
                    sqlConnection.State == ConnectionState.Broken))))
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");

                sqlConnection.Close();
                return dataset.Tables["table"];
                   
            }
            catch(Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                LogHelpers.Write("ERROR Message :: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }
        }
    }
}
