using ggLeapAdminTestProject.Pages;
using ggLeapAutomationFramework.Base;
using ggLeapAutomationFramework.Config;
using ggLeapAutomationFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ggLeapAdminTestProject.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        [Given(@"user navigates to ggLeap web admin")]
        public void GivenUserNavigatesToGgLeapWebAdmin()
        {
            NavigateSite();
            CurrentPage = GetInstance<LoginPage>();
        }

        [When(@"user enters username and password")]
        public void WhenUserEntersUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Settings.UserName, Settings.Password);
        }

        [When(@"user clicks login button")]
        public void WhenUserClicksLoginButton()
        {
            CurrentPage.As<LoginPage>().ClickLoginButton();
            Thread.Sleep(30000);
        }

        [Then(@"user should be logged in successfully")]
        public void ThenUserShouldBeLoggedInSuccessfully()
        {
            //Thread.Sleep(5000);
            //DriverContext.Driver.WaitForPageLoaded();
            CurrentPage = CurrentPage.As<LoginPage>().clickUsersLinkFromLeftMenu();

            //DriverContext.Driver.WaitForPageLoaded();
            bool result = CurrentPage.As<UsersPage>().IsUsersHeaderExists();
            Assert.IsTrue(result);
        }
    }
}
