using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace IHSFramework.Base
{
    public class BasePage : Base
    {
        public static IAlert Alert { get; set; }

        public static Actions Action { get; set; }

 
        //Page Initialization
        public BasePage()
        {
            PageFactory.InitElements(DriverContext, this);
        }


    }
}
