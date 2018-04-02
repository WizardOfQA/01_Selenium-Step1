using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class WaitHelper
    {
        private static IWebElement element;
        public static void WaitForElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("header-GlobalAccountFlyout-flyout-link")));
        }
    }
}
