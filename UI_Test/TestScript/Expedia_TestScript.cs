using System;
using System.Collections.Generic;
using System.Threading;
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UI_TestScript
{
    [TestClass]
    public class Expedia_TestScript
    {
        [TestCategory("Expedia.com")]
        [TestMethod]
        public void User_Can_Search_Vacation()
        {
            // Navigate to Expedia website
            NavigationHelper.NavigateToUrl("https://www.expedia.com");

            // Origin
            TextBoxHelper.TypeInTextBox(By.Id("package-origin-hp-package"), "Seattle, WA (SEA-Seattle - Tacoma Intl.)");

            // Destination
            TextBoxHelper.TypeInTextBox(By.Id("package-destination-hp-package"), "Barcelona El Prat Airport (BCN), Spain");
            
            // Calrendar for Departing
            GenericHelper.GetElement(By.Id("package-departing-hp-package")).Click();
            ButtonHelper.ClickButton(By.XPath("//div[@class='datepicker-cal-month'][2]//button[.='1']"));

            // Calrendar for Returning
            GenericHelper.GetElement(By.Id("package-returning-hp-package")).Click();
            ButtonHelper.ClickButton(By.XPath("//div[@class='datepicker-cal-month'][2]//button[.='20']"));

            // Preferred class
            DropDownHelper.SelectElement(By.Id("package-advanced-preferred-class-hp-package"), "Premium economy");

            // Submit
            ButtonHelper.ClickButton(By.Id("search-button-hp-package"));

            // Wait for the Title in the result page
            WaitHelper.WaitForTitle("Barcelona Intl. (BCN) Hotel Search Results | Expedia", 20, 500);

            // Assertion
            Assert.AreEqual("Barcelona Intl. (BCN) Hotel Search Results | Expedia", ObjectRepository.Driver.Title);
        }
    }
}
