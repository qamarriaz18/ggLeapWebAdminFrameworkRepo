using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.XPath;
using System.IO;
using ggLeapAutomationFramework.Base;

namespace ggLeapAutomationFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem browserType;
            XPathItem userName;
            XPathItem password;
            XPathItem testtype;
            XPathItem isLog;
            XPathItem logPath;
            XPathItem buildName;
            XPathItem isReporting;

            string strFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            aut = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/AUT");
            browserType = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/Browser");
            userName = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/UserName");
            password = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/Password");
            testtype = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/TestType");
            isLog = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/IsLog");
            logPath = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/LogPath");
            buildName = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/Build");
            isReporting = navigator.SelectSingleNode("ggLeapAutomationFramework/RunSettings/IsReporting");

            Settings.AUT = aut.ToString();
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browserType.Value.ToString());
            Settings.UserName = userName.ToString();
            Settings.Password = password.ToString();

            Settings.TestType = testtype.ToString();
            Settings.Build = buildName.ToString();
            Settings.IsLog = isLog.ToString();
            Settings.LogPath = logPath.ToString();
            Settings.IsReporting = isReporting.ToString();

        }
    }
}
