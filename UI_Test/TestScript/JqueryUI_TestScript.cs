using System;
using System.Threading;
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UI_TestScript
{
    [TestClass]
    public class JqueryUI_TestScript
    {
        [TestCategory("JqueryUI.com")]
        [TestMethod]
        public void User_Can_Drag_And_Drop_The_Square()
        {
            NavigationHelper.NavigateToUrl("https://jqueryui.com/droppable/");

            // Move focus to iFrame
            WindowHelper.SwitchToiFrame(By.XPath("//iframe[@class='demo-frame']"));
            Thread.Sleep(2000);

            // Drag the small square inside the big square
            MouseActionHelper.DragNDrop(By.Id("draggable"), By.Id("droppable"));
            Thread.Sleep(2000);

            // Assertion
            Assert.AreEqual("ui-widget-header ui-droppable ui-state-highlight", 
                             GenericHelper.GetElement(By.Id("droppable")).GetAttribute("class"));
        }

        [TestCategory("JqueryUI.com")]
        [TestMethod]
        public void User_Can_Sort_Using_Drag()
        {
            NavigationHelper.NavigateToUrl("https://jqueryui.com/sortable/");

            // Move focus to iFrame
            WindowHelper.SwitchToiFrame(By.XPath("//iframe[@class='demo-frame']"));
            Thread.Sleep(2000);

            // Click hold Item 7 and drag to Item 2
            MouseActionHelper.ClickHoldAndDrag(By.XPath("//li[.='Item 7']"), By.XPath("//li[.='Item 2']/span"));
            Thread.Sleep(2000);

            // Assertion
            Assert.AreEqual("Item 7", GenericHelper.GetElement(By.XPath("//ul[@id='sortable']/li[2]")).Text);
        }
    }
}
