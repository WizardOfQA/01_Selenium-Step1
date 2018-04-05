using System;
using System.Configuration;
using System.Threading;
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Configuration;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UI_Test
{
    [TestClass]
    public class UI_TestScript
    {
        [TestCategory("Stackoverflow.com")]
        [TestMethod]
        public void User_Can_Navigate_To_HomePage()
        {
            // Navigate to Stackoverflow web site.
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());

            // Assertion
            Assert.AreEqual("Stack Overflow - Where Developers Learn, Share, & Build Careers", WindowHelper.GetTitle());
        }

        [TestCategory("Stackoverflow.com")]
        [TestMethod]
        public void Valid_User_Can_LogIn()
        {
            // Navigate to Stackoverflow Web site
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());

            // Click Login menu button
            ButtonHelper.ClickButton(By.LinkText("Log In"));

            // User name
            TextBoxHelper.TypeInTextBox(By.Id("email"), ObjectRepository.Config.GetUserName());

            // Password
            TextBoxHelper.TypeInTextBox(By.Id("password"), ObjectRepository.Config.GetPassword());

            // Submit
            ButtonHelper.ClickButton(By.Id("submit-button"));

            // Wait for 30 sec
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // Click profile image
            ButtonHelper.ClickButton(By.XPath("//img[@src='https://www.gravatar.com/avatar/39f5b43a2d091b4e142c232528fcddcb?s=48&d=identicon&r=PG&f=1']"));

            // Assertion
            Assert.AreEqual("Toby", GenericHelper.GetElement(By.XPath("//div[@class='name']")).Text);
        }

        [TestCategory("Stackoverflow.com")]
        [TestMethod]
        public void User_Can_Serch_Job_With_Advanced_Search()
        {
            // Navigate to Stackoverflow web site
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());

            // Go to Developer Jobs
            ButtonHelper.ClickButton(By.Id("nav-jobs"));

            // Enter 'qa' on Search all jobs textbox
            TextBoxHelper.TypeInTextBox(By.Id("q"), "qa");

            // Click Advanced Search button
            ButtonHelper.ClickButton(By.CssSelector("button.btn.icon-advanced-search.js-trigger.js-show-filters"));

            // Click the Perks icon
            ButtonHelper.ClickButton(By.LinkText("Perks"));

            // Check on "Offers remote" checkbox
            CheckBoxHelper.CheckOnCheckBox(By.Id("r"));

            // Click Search button.
            ButtonHelper.ClickButton(By.XPath("//div/button[. = 'Search']"));

            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // Get the text for Advanced options displayed in the result page
            string actual = GenericHelper.GetElement(By.XPath("//span[@data-key='r']")).Text;

            // Assertion
            Assert.AreEqual("offers remote", actual);
        }
       
    }
}
