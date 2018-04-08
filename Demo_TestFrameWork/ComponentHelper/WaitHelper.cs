using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class WaitHelper
    {
        private static IWebElement element;

        public static void WaitForTitle(string title, int totalSeconds, int checkInterval)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(totalSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.TitleContains(title));
        }
        

        // Once the element is visible, return that element
        public static IWebElement WaitForElement(By locator, int totalSeconds, int checkInterval)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(totalSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            IWebElement element = GenericHelper.GetElement(locator);
            return element;            
        }

        // Use this wait for Auto Suggest List and get all the list
        public static IList<IWebElement> WaitForAutoSuggestList(By locator, int totalSeconds, int checkInterval)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(totalSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(checkInterval),
            };
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return wait.Until(GetAllElements(locator));
        }

        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }
    }
}
