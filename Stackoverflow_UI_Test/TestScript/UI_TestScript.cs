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

namespace Stackoverflow_UI_Test
{
    [TestClass]
    public class UI_TestScript
    {
        [TestMethod]
        public void UserCanNavigateToHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());
            Assert.AreEqual("Stack Overflow - Where Developers Learn, Share, & Build Careers", WindowHelper.GetTitle());
        }


        [TestMethod]
        public void ValidUserCanLogIn()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());

            ButtonHelper.ClickButton(By.LinkText("Log In"));
            TextBoxHelper.TypeInTextBox(By.Id("email"), ObjectRepository.Config.GetUserName());
            TextBoxHelper.TypeInTextBox(By.Id("password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("submit-button"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            ButtonHelper.ClickButton(By.XPath("//img[@src='https://www.gravatar.com/avatar/39f5b43a2d091b4e142c232528fcddcb?s=48&d=identicon&r=PG&f=1']"));
            Assert.AreEqual("Toby", GenericHelper.GetElement(By.XPath("//div[@class='name']")).Text);
        }

        [TestMethod]
        public void UserCanSerchJobWithAdvancedSearch()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());

            // Go to Developer Jobs
            ButtonHelper.ClickButton(By.Id("nav-jobs"));

            TextBoxHelper.TypeInTextBox(By.Id("q"), "qa");
            ButtonHelper.ClickButton(By.CssSelector("button.btn.icon-advanced-search.js-trigger.js-show-filters"));
            ButtonHelper.ClickButton(By.LinkText("Perks"));
            CheckBoxHelper.CheckOnCheckBox(By.Id("r"));
            ButtonHelper.ClickButton(By.XPath("//div/button[. = 'Search']"));

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string actual = GenericHelper.GetElement(By.XPath("//span[@data-key='r']")).Text;
            Console.WriteLine(actual);
            Assert.AreEqual("offers remote", actual);
        }
       
    }
}
