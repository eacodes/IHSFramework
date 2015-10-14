using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSFramework.Utilities
{
    public class PropertyFactory
    {
        public static string TestType { get; set; }

        public static string IsReporting { get; set; }

        public static SqlConnection ReportingConn { get; set; }


        public static SqlConnection ApplicationConnection { get; set; }


        /*****************************************************************************************
        * Global Flag for log file to be used Across the Framework
        * 
        * ***************************************************************************************/
        private static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }

        public static string isLog { get; set; }
        public static string logPath { get; set; }
    }
}
