using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using IHSFramework.Fixtures;
using EAProject.Pages;
using IHSFramework.Base;
using IHSFramework.Utilities;

namespace EAProject.Tests
{

    [TestFixture]
    public class LoginTest : BaseFixture
    {

        [Test]
        public void Test_Login()
        {
            ExcelReader.PopulateInCollection(@"C:\Users\karthik\Documents\visual studio 2015\Projects\IHSFramework\IHSFramework\Resources\Login.xlsx");

            //Version 2
            LoginPage loginPage = new LoginPage();

            //Iterate through all the test cases
            for (int row = 1; row <= ExcelReader.RowCount; row++)
            {
                //Programatically you are saying that, the following operations
                // are for userForm page page
                var userPage = (UserFormPage) loginPage.Login(ExcelReader.ReadData(row, "UserName"),
                    ExcelReader.ReadData(row, "Password"));


                //Check if I have really logged into the app
                if (userPage.IsUserForm())
                    Reporting.WriteTestResults(ExcelReader.ReadData(row, "TCID"),
                        ExcelReader.ReadData(row, "TCDescription"),
                        ExcelReader.ReadData(row, "TCName"),
                        "Userpage is displayed",
                        "Should see userform page",
                        "PASSED");
                else
                    Reporting.WriteTestResults(ExcelReader.ReadData(row, "TCID"),
                        ExcelReader.ReadData(row, "TCDescription"),
                        ExcelReader.ReadData(row, "TCName"),
                        "Userpage is not displayed",
                        "Should see userform page",
                        "FAILED");


                //Logout from the portal
                loginPage.Logout();
            }

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
