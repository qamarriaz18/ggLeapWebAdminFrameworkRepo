using ggLeapAdminTestProject.Pages;
using ggLeapAutomationFramework.Base;
using ggLeapAutomationFramework.Config;
using ggLeapAutomationFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using System;
using System.Threading;


namespace ggLeapAdminTestProject
{
    //Initialize UnitTest1 class with TestInitialized class and Inherit TestInitialized Class with Base class.
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        //string url = ConfigReader.InitializeTest();
      
        
        //[TestMethod]
        public void TestMethod1()
        {
            //DriverContext.Driver = new ChromeDriver();
            //DriverContext.Driver.Navigate().GoToUrl(url);
            /*
             This Code section is related to ExcelHelper "ExcelDataReader" dll throwing error
             */
            //string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            // ExcelHelpers.PopulateInCollection(fileName);

            //ConfigReader.SetFrameworkSettings();

            //LogHelpers.CreateLogFile();

            //OpenBrowser(BrowserType.Chrome);
            //LogHelpers.Write("Browser opened!");
           // DriverContext.Browser.GoToUrl(Settings.AUT);
            //LogHelpers.Write("User Navigated to ggLeap Login Page");

            //LoginPage
            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().Login(Settings.UserName, Settings.Password);

            //ExcelDataReader code section to input username and password after retrieving the values from excel file
            //CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"), ExcelHelpers.ReadData(1, "Password"));

            Thread.Sleep(30000);
            LogHelpers.Write("User logged in successfully to ggLeap");
            //UsersPage
            CurrentPage = CurrentPage.As<LoginPage>().clickUsersLinkFromLeftMenu();
            Thread.Sleep(3000);
            CurrentPage.As<UsersPage>().CheckIfElementExist();
            //bool result = CurrentPage.As<UsersPage>().IsUsersHeaderExists();           
            //LogHelpers.Write("User clicked Users button from Left Menu bar : " + result);
            
            //CurrentPage.As<UsersPage>().clickAddUserButton();
            Thread.Sleep(3000);


        }
        
        //Method to Read Data from Table and perform action on it.
        public void TableOperation()
        {
            LogHelpers.CreateLogFile();

            //OpenBrowser(BrowserType.Chrome);
            LogHelpers.Write("Browser opened!");
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("User Navigated to ggLeap Login Page");
            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().Login(Settings.UserName, Settings.Password);
            Thread.Sleep(30000);
            LogHelpers.Write("User logged in successfully to ggLeap");
            //UsersPage
            CurrentPage = CurrentPage.As<LoginPage>().clickUsersLinkFromLeftMenu();
            Thread.Sleep(3000);
            bool result = CurrentPage.As<UsersPage>().IsUsersHeaderExists();
            LogHelpers.Write("User clicked Users button from Left Menu bar : " + result);
            Thread.Sleep(3000);

            var table = CurrentPage.As<UsersPage>().GetUsersList();

            HtmlTableHelper.ReadTable(table);

            HtmlTableHelper.PerformActionOnCell("2", "Username", "qamar951", "");
            Thread.Sleep(10000);
        }

    }
}

