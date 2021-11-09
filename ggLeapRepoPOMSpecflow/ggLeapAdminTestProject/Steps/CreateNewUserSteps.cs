using ggLeapAdminTestProject.Pages;
using ggLeapAutomationFramework.Base;
using ggLeapAutomationFramework.Config;
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
    public class CreateNewUserSteps : BaseStep
    {
        [Given(@"user navigates to ggLeap webAdmin")]
        public void GivenUserNavigatesToGgLeapWebAdmin()
        {
            NavigateSite();
            CurrentPage = GetInstance<LoginPage>();
        }

        [When(@"user enter username and password")]
        public void WhenUserEnterUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Settings.UserName, Settings.Password);
            
        }

        [When(@"user click login button")]
        public void WhenUserClickLoginButton()
        {
            CurrentPage.As<LoginPage>().ClickLoginButton();
            
            Thread.Sleep(30000);
        }

        [Then(@"user should login successfully")]
        public void ThenUserShouldLoginSuccessfully()
        {
            
            CurrentPage = CurrentPage.As<LoginPage>().clickUsersLinkFromLeftMenu();
            
        }

        [When(@"user clicks on Users from left menu bar")]
        public void WhenUserClicksOnUsersFromLeftMenuBar()
        {
            //DriverContext.Driver.WaitForPageLoaded();
            bool result = CurrentPage.As<UsersPage>().IsUsersHeaderExists();
            //Console.WriteLine("Debugger Here");
            Assert.IsTrue(result);
        }

        [Then(@"Users page should be opened successfully")]
        public void ThenUsersPageShouldBeOpenedSuccessfully()
        {
            Thread.Sleep(3000);
            Console.WriteLine("User Page opened successfully");
        }

        [When(@"user clicks Add User button")]
        public void WhenUserClicksAddUserButton()
        {
            CurrentPage.As<UsersPage>().clickAddUserButton();
        }

        [When(@"user input data to create a new user")]
        public void WhenUserInputDataToCreateANewUser()
        {
            Thread.Sleep(3000);
            CurrentPage.As<UsersPage>().inputDataToCreateANewUser();
        }

        [Then(@"new user should be created successfully")]
        public void ThenNewUserShouldBeCreatedSuccessfully()
        {
            Thread.Sleep(3000);
            //bool result =
            CurrentPage.As<UsersPage>().clickSaveButtonToCreateAUser();
            //Assert.IsTrue(result);
        }

        [When(@"user clicks button to expand search section")]
        public void WhenUserClicksButtonToExpandSearchSection()
        {
            Thread.Sleep(3000);
            CurrentPage.As<UsersPage>().clickSearchButtonToExpandSearchSection();
        }

        [When(@"user input username")]
        public void WhenUserInputUsername()
        {
            Thread.Sleep(3000);
            CurrentPage.As<UsersPage>().inputUserNameToFilterTheResult();
        }

        [Then(@"user should be able to retrieve user")]
        public void ThenUserShouldBeAbleToRetrieveUser()
        {
            Thread.Sleep(3000);
            bool result = CurrentPage.As<UsersPage>().getUserNameValueFromDataGrid();
            Assert.IsTrue(result);

        }

        [When(@"user input email in search field")]
        public void WhenUserInputEmailInSearchField()
        {
            Thread.Sleep(3000);
            CurrentPage.As<UsersPage>().inputUserEmailToFilterResult();
        }

        [Then(@"user should be able to retrieve user successfully")]
        public void ThenUserShouldBeAbleToRetrieveUserSuccessfully()
        {
            Thread.Sleep(3000);
            bool result = CurrentPage.As<UsersPage>().getUserEmailValueFromDataGrid();
            Assert.IsTrue(result);
        }

    }
}
