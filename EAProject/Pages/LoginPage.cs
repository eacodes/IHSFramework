using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using IHSFramework.Base;

namespace EAProject.Pages
{
    public class LoginPage : BasePage
    {

        //Version 2
        public LoginPage() : base()
        {

        }


        // -- Version 1
        //public LoginPage(IWebDriver driver)
        //{
        //    PageFactory.InitElements(driver, this);
        //}

        //Login textbox
        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName;

        //Password textbox
        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword;

        //Login Button
        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement btnLogin;



        /// <summary>
        /// Logs into application and return a UserForm page
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>UserFormPage</returns>
        public BasePage Login(string userName, string password)
        {

            bool firstTimeUser = false;
            txtUserName.SendKeys("admin");
            txtPassword.SendKeys("admin");
            btnLogin.Submit();
            return new UserFormPage();
        }

        public void ForgetPassword(string emailAddress)
        {

        }


        public void SocialLogin(string socialType)
        {

        }












    }
}

