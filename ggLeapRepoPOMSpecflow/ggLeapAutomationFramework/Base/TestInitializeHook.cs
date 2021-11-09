using ggLeapAutomationFramework.Config;
using ggLeapAutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using Microsoft.Edge.SeleniumTools;


namespace ggLeapAutomationFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;
        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }
        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open the Browser
            OpenBrowser(Settings.BrowserType);

            LogHelpers.Write("Initialized Framework Settings");
        }
        private void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions optionChrome = new ChromeOptions();
                    optionChrome.AddArgument("--start-maximized");
                    DriverContext.Driver = new ChromeDriver(optionChrome);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Driver.Manage().Window.Maximize();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Edge:
                    EdgeOptions options = new EdgeOptions();
                    options.UseChromium = true;
                    DriverContext.Driver = new EdgeDriver(options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Opera:
                    DriverContext.Driver = new OperaDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("User Navigated to ggLeap Login Page");
        }

    }
}
