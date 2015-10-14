using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

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
