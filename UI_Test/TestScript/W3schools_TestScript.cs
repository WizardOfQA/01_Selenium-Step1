using System;
using System.Collections.ObjectModel;
using System.Threading;
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UI_TestScript
{
    [TestClass]
    public class W3schools_TestScript
    {      
        [TestCategory("W3schoos.com")]
        [TestMethod]
        public void User_Can_Open_And_Close_Multiple_Child_Windows()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");

            // Open 2 child windows
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/div[4]/a"));
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/div[4]/a"));

            // Point to the first child window
            WindowHelper.SwitchToWindow(1);

            // Click 'Change Orientation' button in the first child window
            ButtonHelper.ClickButton(By.XPath("//div[5]//div/a[4]"));

            // close all the child windows and go back to the parent window.
            WindowHelper.SwitchToParent();

            // Assertion
            Assert.AreEqual("JavaScript Popup Boxes", WindowHelper.GetTitle());
        }

        [TestCategory("W3schoos.com")]
        [TestMethod]
        public void User_Can_Click_Button_Inside_Iframe()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            
            // Open a child window
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/div[4]/a"));

            WindowHelper.SwitchToWindow(1);  // Open the child window

            // Change the frame
            WindowHelper.SwitchToiFrame(By.Id("iframeResult"));

            // Click the button inside iframe
            ButtonHelper.ClickButton(By.XPath("//button[.='Try it']"));

            Thread.Sleep(2000);

            // Assertion
            Assert.IsTrue(JavaScriptPopupHelper.IsPopupPresent());

            // Click on pupup botton to close it
            JavaScriptPopupHelper.ClickOKOnPopup();

            Thread.Sleep(2000);            
        }
    }
}
