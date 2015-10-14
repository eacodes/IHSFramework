using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IHSFramework.Utilities
{
    public static class DbExtensions
    {


        /// <summary>
        /// Open Database Connectivity
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="connectionString"></param>
        /// <returns>SqlConnection for the connection opened</returns>
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                //Create a connectivity to sql Connection
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                //return sqlConnection
                return sqlConnection;
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
            }
            //return null if no connection establishes
            return null;
        }


        /// <summary>
        /// BDDDBClose the Database connectivity
        /// </summary>
        /// <param name="sqlConnection"></param>
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
            }
        }


        /// <summary>
        /// ExecuteQuery for the given QueryString
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Connection"></param>
        public static DataTable ExecuteQuery(this SqlConnection Conn, string QueryString)
        {
            DataSet dataSet;
            try
            {
                if (Conn == null || ((Conn != null && (Conn.State == ConnectionState.Closed || Conn.State == ConnectionState.Broken))))
                    Conn.Open();
                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(QueryString, Conn);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                dataAdaptor.Fill(dataSet, "table");
                Conn.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception ex)
            {
                dataSet = null;
                Conn.Close();
                return null;
            }
            finally
            {
                Conn.Close();
                dataSet = null;
            }

        }


        /// <summary>
        /// Execute Stored Procedure with the Parameters passed
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="procname"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteProcWithParamsDT(this SqlConnection Conn, string procname, Hashtable parameters)
        {
            DataSet dataSet;
            try
            {
                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(procname, Conn);
                dataAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (DictionaryEntry de in parameters)
                    {
                        SqlParameter sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());
                        dataAdaptor.SelectCommand.Parameters.Add(sp);
                    }

                dataSet = new DataSet();
                dataAdaptor.Fill(dataSet, "table");
                Conn.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception ex)
            {
                dataSet = null;
                Conn.Close();
                return null;
            }
            finally
            {
                Conn.Close();
                dataSet = null;
            }

        }

    }
}
