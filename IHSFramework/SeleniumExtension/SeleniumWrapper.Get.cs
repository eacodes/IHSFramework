using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace IHSFramework.SeleniumExtension
{
    public static partial class SeleniumWrapper
    {

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static bool GetChecked(IWebElement element)
        {
            return element.Selected;
        }

        public static void SwitchNextWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchCurrentWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }


    }
}
