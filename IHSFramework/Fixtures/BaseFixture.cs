using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using IHSFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;

namespace IHSFramework.Fixtures
{
    [TestFixture]
    public class BaseFixture : Base.Base
    {

        /// <summary>
        /// Setup will be called only once
        /// 
        /// </summary>
        [SetUp]
        public void CodeSetup()
        {

            //Connecting to Reporting database
            PropertyFactory.ReportingConn = PropertyFactory.ReportingConn.
                DBConnect(ConfigurationManager.ConnectionStrings["ReportingDb"].ToString());

            //Query the database
            PropertyFactory.ReportingConn.ExecuteQuery("select * from tblTestCycle");

            DriverContext = new FirefoxDriver();

            //Contains the URL
            string autURL = ConfigurationManager.AppSettings["ApplicationURL"].ToString();

            DriverContext.Navigate().GoToUrl(autURL);
        }


        [TearDown]
        public void CodeTearDown()
        {
            DriverContext.Close();
        }

    }
}
