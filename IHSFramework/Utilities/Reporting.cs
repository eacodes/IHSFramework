using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSFramework.Utilities
{

    /// <summary>
    /// Extended Reporting Class
    /// </summary>
    public static class Reporting
    {
        /// <summary>
        /// CreateTestCycle for this run
        /// </summary>
        public static void CreateTestCycle()
        {
            if (PropertyFactory.IsReporting == "Y")
                try
                {
                    Hashtable table = new Hashtable();
                    table.Add("AUT", "Execute Automation App");
                    table.Add("ExecutedBy", "Karthik KK");
                    table.Add("RequestedBy", "Karthik KK");
                    table.Add("BuildNo", "1.0.0");
                    table.Add("ApplicationVersion", "1.0");
                    table.Add("MachineName", Environment.MachineName);
                    table.Add("TestType", 1);

                    PropertyFactory.ReportingConn.ExecuteProcWithParamsDT("sp_CreateTestCycleID", table);

                }
                catch (Exception e)
                {
                    Log.Write(e.Message);
                }
        }

        /// <summary>
        /// WriteTestResults
        /// </summary>
        public static void WriteTestResults(string TestCaseID, string TestCaseDesc, string scenarioName, string Actual, string Expected, string Result)
        {

            if (PropertyFactory.IsReporting == "Y")
                try
                {
                    Hashtable table = new Hashtable();
                    table.Add("TestCaseID", TestCaseID);
                    table.Add("TestCaseDesc", TestCaseDesc);
                    table.Add("ModuleName", scenarioName);
                    table.Add("Actual", Actual);
                    table.Add("Expected", Expected);
                    table.Add("Result", Result);
                    PropertyFactory.ReportingConn.ExecuteProcWithParamsDT("sp_InsertResult", table);
                }
                catch (Exception e)
                {
                    Log.Write(e.Message);
                }
        }


    }
}
