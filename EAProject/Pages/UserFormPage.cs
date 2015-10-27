using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using IHSFramework.Base;
using IHSFramework.SeleniumExtension;

namespace EAProject.Pages
{
    public class UserFormPage : BasePage
    {


        public UserFormPage() :base()
        {
          
        }

        [FindsBy(How = How.Name, Using = "TitleId")]
        public IWebElement ddlTitle { get; set; }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement txtinitial { get; set; }

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "MiddleName")]
        public IWebElement txtMiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement radioFemale { get; set; }

        [FindsBy(How = How.Name, Using = "Hindi")]
        public IWebElement cboxHindi { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement btnSave { get; set; }


        [FindsBy(How = How.LinkText, Using = "HtmlPopup ")]
        public IWebElement lnkPopup { get; set; }

        [FindsBy(How = How.Name, Using = "generate")]
        public IWebElement BtnGenerateAlert;

        [FindsBy(How = How.XPath, Using = "//li[@id='item1']")]
        public IWebElement DragDropSrc;

        [FindsBy(How = How.XPath, Using = "//li[@id='item3']")]
        public IWebElement DragDropDst;



        public void ClickAlert()
        {
            BtnGenerateAlert.Click();

            DriverContext.PerformAlertAction(AlertAction.Ok);

            
        }


        public bool IsUserForm()
        {
            if (txtFirstName.Displayed)
                return true;
            else
                return false;
        }




        public void FillUserFrom(string Initial, string FristName, string MiddleName, string Title)
        {
            //SeleniumWrapper.SelectDDLv2(ddlTitle,Title);

            //Coming from Extension methods
            ddlTitle.SelectDDL(Title);
            txtinitial.EnterText(Initial);
            txtFirstName.EnterTextWithClean(FristName);
            txtMiddleName.EnterTextWithClean(MiddleName);
            radioFemale.Click();
            cboxHindi.Click();

            //Click popup
            lnkPopup.Click();

            //Switch to next window
            //SeleniumWrapper.SwitchNextWindow();

            // -- Using Extension methods
            DriverContext.SwitchNextWindow();

            //Type the values
            txtinitial.SendKeys(Initial + "    p");
            txtFirstName.SendKeys(FristName + "     p");
            txtMiddleName.SendKeys(MiddleName + "    p");

            //Switch to current window
            DriverContext.SwitchCurrentWindow();

            txtinitial.SendKeys(Initial + "    KKK");
            txtFirstName.SendKeys(FristName + "     KKK");
            txtMiddleName.SendKeys(MiddleName + "    KKK");




        }



    }
}
