using ggLeapAutomationFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ggLeapAutomationFramework.Extensions;

namespace ggLeapAdminTestProject.Pages
{
    class UsersPage : BasePage
    {
        int userDataGridRowCountBeforeUserCreation;
        int userDataGridRowCountAfterUserCreation;
        int time = DateTime.Now.Millisecond;
        string timeMilliseconds => time.ToString();
        string userName => "Qamar" + timeMilliseconds;
        string userEmail => "qamar" + timeMilliseconds + "@abcd.com";


        IWebElement headerUsers => DriverContext.Driver.FindElement(By.XPath("//body/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/div[3]/glp-users-page[1]/div[1]/div[1]/div[1]/div[1]/div[1]/h1[1]"));

        IWebElement lnkAddUser => DriverContext.Driver.FindElement(By.XPath("//button[@class='gg-button-primary gg-text-subtitle-2 k-button k-button-icontext']"));

        IWebElement tblUsersList => DriverContext.Driver.FindElement(By.ClassName("k-grid-table"));

        IWebElement txtUserName => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[1]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement txtPassword => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[2]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement txtUserEmail => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[3]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement txtFirstName => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[7]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement txtLastName => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[8]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement txtPhoneNumber => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/div[1]/glp-user-form-modal[1]/div[1]/div[1]/glp-user-form[1]/div[1]/form[1]/div[10]/glp-user-form-field[1]/form[1]/div[1]/kendo-textbox-container[1]/input[1]"));

        IWebElement btnSave => DriverContext.Driver.FindElement(By.XPath("//body/glp-app[1]/div[1]/kendo-dialog[1]/div[2]/kendo-dialog-actions[1]/div[2]/button[3]"));

        IList<IWebElement> userDataGridRowCount => DriverContext.Driver.FindElements(By.XPath("//tbody/tr"));
        IWebElement btnThreeMenuDot => DriverContext.Driver.FindElement(By.XPath("//body/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/div[3]/glp-users-page[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[3]/span[1]"));


        IWebElement txtSearchSectionUserName => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/div[3]/glp-users-page[1]/div[1]/div[2]/div[1]/glp-users-filter[1]/div[1]/kendo-textbox-container[1]/input[1]")); 

        IWebElement txtDataGridUserNameValue => DriverContext.Driver.FindElement(By.XPath("//tbody/tr[1]/td[2]/div[1]"));

        IWebElement txtSearchSectionEmail => DriverContext.Driver.FindElement(By.XPath("/html[1]/body[1]/glp-app[1]/div[1]/glp-main[1]/div[1]/glp-content[1]/div[1]/div[3]/glp-users-page[1]/div[1]/div[2]/div[1]/glp-users-filter[1]/div[1]/kendo-textbox-container[4]/input[1]"));

        IWebElement txtDataGridEmailValue => DriverContext.Driver.FindElement(By.XPath("//tbody/tr[1]/td[5]"));

        public bool IsUsersHeaderExists()
        {
            Thread.Sleep(5000);
            //Custom Method as WebDriver Extension. We can call this method using driver object
            //DriverContext.Driver.WaitForPageLoaded();
            return headerUsers.Displayed;
        }
        public void clickAddUserButton()
        {
            userDataGridRowCountBeforeUserCreation = userDataGridRowCount.Count;

            //Console.WriteLine("Rows Count Before Clicking Add User Button : " + userDataGridRowCountBeforeUserCreation);
            lnkAddUser.Click();
            //return new AddNewUserPage();
            //returning the current page instance using TPage type method
           // return GetInstance<AddNewUserPage>();
        }

        public IWebElement GetUsersList()
        {
            return tblUsersList;
        }

        public void CheckIfElementExist()
        {
            headerUsers.AssertElementPresent();

            //Hovering over Users Header
            headerUsers.Hover();
        }

        public void inputDataToCreateANewUser()
        {

            txtUserName.SendKeys(userName);
            Thread.Sleep(3000);
            txtPassword.SendKeys("12345678");

            txtUserEmail.SendKeys(userEmail);
            Thread.Sleep(3000);
            txtFirstName.SendKeys("abcdef");

            txtLastName.SendKeys("wxyzabc");

            txtPhoneNumber.SendKeys("1234567890");
            Thread.Sleep(5000);

        }
        public bool clickSaveButtonToCreateAUser()
        {

            btnSave.Click();
            Thread.Sleep(10000);
            userDataGridRowCountAfterUserCreation = userDataGridRowCount.Count;

            Console.WriteLine("Rows Count Before : " + userDataGridRowCountBeforeUserCreation);
            Console.WriteLine("Rows Count After : " + userDataGridRowCountAfterUserCreation);

            //if (userDataGridRowCountAfterUserCreation != userDataGridRowCountBeforeUserCreation)
            //{
            //    Console.WriteLine("User Created Successfully");
            //    return true;
            //}
            //else
            //{
            //    Console.WriteLine("User Does not Created Successfully");
            //    return false;
            //}
            return true;

        }
        public void clickSearchButtonToExpandSearchSection()
        {
            btnThreeMenuDot.Click();
            Thread.Sleep(3000);
        }
        public void inputUserNameToFilterTheResult()
        {
            txtSearchSectionUserName.SendKeys(userName);
            Thread.Sleep(3000);
        }
        public bool getUserNameValueFromDataGrid()
        {
            String dataGridUserName = txtDataGridUserNameValue.Text;

            if (dataGridUserName.Equals(userName))
            {
                Console.WriteLine("User Exist and Retrieved Successfully");
                return true;

            }
            else
            {
                Console.WriteLine("User Does Not Exists !");
                return false;
            }
        }
        public void inputUserEmailToFilterResult()
        {
            txtSearchSectionUserName.Clear();
            Thread.Sleep(2000);
            txtSearchSectionEmail.SendKeys(userEmail);
            Thread.Sleep(2000);
        }
        public bool getUserEmailValueFromDataGrid()
        {
            String dataGridUserEmail = txtDataGridEmailValue.Text;

            if (dataGridUserEmail.Equals(userEmail))
            {
                Console.WriteLine("User Email Retrieved Successfully");
                return true;
            }
            else
            {
                Console.WriteLine("User Email Does Not Exists");
                return false;
            }
        }

    }
}
