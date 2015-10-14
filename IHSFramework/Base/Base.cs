using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace IHSFramework.Base
{
    public abstract class Base
    {
        //Drivers in BasePage
        public static RemoteWebDriver DriverContext { get; set; }


    }
}
