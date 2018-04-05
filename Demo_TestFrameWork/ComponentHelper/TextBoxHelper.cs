using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class TextBoxHelper
    {
        private static IWebElement element;
        public static void TypeInTextBox(By locator, string inputText)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(inputText);
        }

        public static void ClearTextBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
        }
    }
}
