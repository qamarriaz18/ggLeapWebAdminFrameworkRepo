using ggLeapAutomationFramework.Base;
using ggLeapAutomationFramework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ggLeapAdminTestProject
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize(): base(Settings.BrowserType)
        {
            InitializeSettings();
            //NavigateSite();
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }

        //[AfterFeature]
        //public static void TestStart1()
        //{
        //    //HookInitialize init = new HookInitialize();
        //}
    }
}
