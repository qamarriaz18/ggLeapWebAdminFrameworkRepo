using ggLeapAutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ggLeapAutomationFramework.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static string Build { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReporting { get; set; }
    }
}
