using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ggLeapAutomationFramework.Base
{
    public class Base
    {
        public BasePage CurrentPage { get; set; }

        private IWebDriver _driver { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            //using c# reflection 
            return (TPage)Activator.CreateInstance(typeof(TPage));

        }
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }   
}
