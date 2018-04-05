using System;
using System.Collections.Generic;
using System.Threading;
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stackoverflow_UI_Test.TestScript
{
    [TestClass]
    public class Microsoft_TestScript
    {
        [TestCategory("Microsoft.com")]
        [TestMethod]
        public void User_Can_Search_Product_Using_AutoComplete()
        {
            // Navigate to microsoft website
            NavigationHelper.NavigateToUrl("https://www.microsoft.com");

            // Click Search box
            ButtonHelper.ClickButton(By.Id("search"));

            // Enter 's' in the search box
            TextBoxHelper.TypeInTextBox(By.Id("cli_shellHeaderSearchInput"), "s");
            Thread.Sleep(2000);

            // Get the whole list from AutoComplete
            IList<IWebElement> elements =
                WaitHelper.WaitForAutoSuggestList(By.XPath("//ul[@id='universal-header-search-auto-suggest-ul']/child::li"), 40, 500);

            // If the option is "Surface Laptop", select it.
            foreach (var el in elements)
            {
                if (el.Text.Equals("Surface Laptop"))
                {
                    el.Click();
                    break;
                }                                   
            }

            // Wait for the Title in the result page
            WaitHelper.WaitForTitle("Microsoft.com site search results", 20, 500);

            // Assertion
            Assert.AreEqual("Microsoft.com site search results", ObjectRepository.Driver.Title);
        }
    }
}
