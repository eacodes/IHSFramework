using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using IHSFramework.Fixtures;
using EAProject.Pages;
using IHSFramework.Utilities;

namespace EAProject.Tests
{

    [TestFixture]
    public class LoginTest : BaseFixture
    {


        public void CleanUserData(string userName)
        {
            PropertyFactory.ApplicationConnection.ExecuteQuery
                ("Delete from tblUser where UserName={0}" + userName);
        }



        [Test]
        public void Test_UserForm_DataEntry()
        {
            //Version 2
            LoginPage loginPage = new LoginPage();

            //Programatically you are saying that, the following operations
            // are for userForm page page
            UserFormPage userPage = (UserFormPage)loginPage.Login("admin", "admin");

            userPage.FillUserFrom("tt", "firstName", "middlename", "Ms.");

            
        }

        [Test]
        public void Test_FillPopup()
        {
            LoginPage loginPage = new LoginPage();

            //Programatically you are saying that, the following operations
            // are for userForm page page
            UserFormPage userPage = (UserFormPage)loginPage.Login("admin", "admin");

            userPage.ClickAlert();
        }

    }
}
