using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSFramework.Utilities
{
    public class Log
    {
        //static Log()
        //{
        //    PropertyFactory.isLog = ConfigurationManager.AppSettings["Logging"].ToString();
        //    PropertyFactory.logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
        //}

        //Global declaration
        private static string logFileName = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now);
        public static StreamWriter streamw = null;

        // ****************************************************************************************************************
        // Function : CreateLogFile
        // Author: Karthik KK
        // Return Type: 
        // Description: Function to create or append log file
        // Date: 
        // ****************************************************************************************************************

        public static void CreateLogFile()
        {
            if (PropertyFactory.isLog == "Y")
                if (PropertyFactory.FileCreated == false)
                {
                    //Get the Log path from App.config file
                    string dir = PropertyFactory.logPath;
                    if (Directory.Exists(dir))
                    {
                        PropertyFactory.FileCreated = true;
                        streamw = File.AppendText(PropertyFactory.logPath + logFileName + ".log");
                    }
                    else
                    {
                        PropertyFactory.FileCreated = true;
                        Directory.CreateDirectory(dir);
                        streamw = File.AppendText(PropertyFactory.logPath + logFileName + ".log");
                    }
                }
        }

        // ****************************************************************************************************************
        // Function : Write
        // Author: Karthik KK
        // Return Type: 
        // Description: Function to input Log Message using the Write Method all over framework
        // Date: 
        // ****************************************************************************************************************

        public static void Write(String logMessage)
        {
            if (PropertyFactory.isLog == "Y")
            {
                streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                streamw.WriteLine("  :{0}", logMessage);
                // Update the underlying file.
                streamw.Flush();
            }
        }

    }
}
