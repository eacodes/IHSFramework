using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IHSFramework.SeleniumExtension
{
   
    public enum AlertAction
    {
        Ok,
        Cancel,
        Yes,
        No
    }

    public static partial class SeleniumWrapper
    {
        
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        public static void EnterTextWithClean(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }


        public static void SelectDDL(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }



        public static void PerformAlertAction(this IWebDriver driver, AlertAction action)
        {
            //Switch to the Alert window
            var alert = driver.SwitchTo().Alert();
            if(action == AlertAction.Ok)
                alert.Accept();
            if(action == AlertAction.Cancel)
                alert.Dismiss();
        }

















    }
}
