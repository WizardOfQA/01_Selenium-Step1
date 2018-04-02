using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class LinkHelper
    {
        private static IWebElement element;
        public static void ClickLink(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }
    }
}
