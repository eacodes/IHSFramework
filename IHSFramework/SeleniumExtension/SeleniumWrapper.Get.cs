using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IHSFramework.SeleniumExtension
{
    public static partial class SeleniumWrapper
    {

        public enum PropertyType
        {
            Name,
            Id,
            XPath
        }

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

        public static void SwitchNextFrameByIndex(this IWebDriver driver,string FrameIndex)
        {
            driver.SwitchTo().Frame(FrameIndex);
        }

        public static void SwitchNextFrameByElement(this IWebDriver driver, IWebElement element)
        {
           
            driver.SwitchTo().Frame(element);
            
        }

        public static void SwitchToCurrentFrame(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

       



    }
}
