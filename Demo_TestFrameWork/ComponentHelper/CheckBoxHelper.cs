using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class CheckBoxHelper
    {
        private static IWebElement element;
        public static bool IsCheckBoxchecked(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string flag = element.GetAttribute("checked");
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }
        public static void CheckOnCheckBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }
    }
}
