using ggLeapAutomationFramework.Base;
using ggLeapAutomationFramework.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ggLeapAdminTestProject.Pages
{
    class LoginPage : BasePage
    {

        //Object for the Login Page
        //[FindsBy(How = How.Id, Using = "username")]
        //IWebElement txtUserName { get; set; }

        //[FindsBy(How = How.Id, Using = "password")]
        //IWebElement txtPassword { get; set; }

        //[FindsBy(How = How.XPath, Using = "//span[contains(text(),'Login')]")]
        //IWebElement btnLogin { get; set; }

        ////[FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Users')]")]
        //[FindsBy(How = How.XPath, Using = "//body/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/glp-menu[1]/div[1]/div[1]/kendo-menu[1]/ul[1]/li[4]/span[1]/a[1]")]
        //IWebElement lnkUsers { get; set; }

        IWebElement txtUserName => DriverContext.Driver.FindElement(By.Id("username"));
        IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("password"));
        IWebElement btnLogin => DriverContext.Driver.FindElement(By.XPath("//span[contains(text(),'Login')]"));
        IWebElement lnkUsers => DriverContext.Driver.FindElement(By.XPath("//body/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/glp-menu[1]/div[1]/div[1]/kendo-menu[1]/ul[1]/li[4]/span[1]/a[1]"));
        public void Login(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            
        }

        public void ClickLoginButton()
        {
            
            btnLogin.Click();
            Thread.Sleep(5000);
        }

        public UsersPage clickUsersLinkFromLeftMenu()
        {
           //DriverContext.Driver.WaitForPageLoaded();
            Thread.Sleep(5000);
            lnkUsers.Click();            
            //returning the current page instance using TPage type method
            return GetInstance<UsersPage>();
        }
        
    }
}
