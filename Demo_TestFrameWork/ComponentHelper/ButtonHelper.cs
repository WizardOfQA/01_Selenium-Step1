using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement element;
        public static bool IsButtonEnabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            return element.Enabled;
        }

        public static void ClickButton(By locator)
        {
            //WaitHelper.WaitForElement(locator);
            element = GenericHelper.GetElement(locator);
            element.Click();
        }

        public static string GetButtonText(By locator)
        {
            element = GenericHelper.GetElement(locator);
            if (element.GetAttribute("value") == null)
            {
                return string.Empty;
            }
            else
                return element.GetAttribute("value");
        }
    }
}
