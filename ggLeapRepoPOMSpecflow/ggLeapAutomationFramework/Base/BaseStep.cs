using ggLeapAutomationFramework.Config;
using ggLeapAutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ggLeapAutomationFramework.Base
{
    public abstract class BaseStep : Base
    {

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("User Navigated to ggLeap Login Page");
        }
    }
}
