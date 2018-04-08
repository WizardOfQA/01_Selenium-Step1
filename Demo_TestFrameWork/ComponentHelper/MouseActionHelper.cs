using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class MouseActionHelper
    {

        public static IWebElement ele;

        public static void MouseRightClick(By locator)
        {
            Actions act = new Actions(ObjectRepository.Driver);
            ele = ObjectRepository.Driver.FindElement(locator);

            act.ContextClick(ele).Build().Perform();
            Thread.Sleep(3000);
        }
        
        public static void DragNDrop(By startElement, By endElement)
        {
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement start = GenericHelper.GetElement(startElement);
            IWebElement target = GenericHelper.GetElement(endElement);
            act.DragAndDrop(start, target).Build().Perform();
            Thread.Sleep(3000);
        }        

        public static void ClickHoldAndDrag(By startElement, By endElement)
        {
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement start = GenericHelper.GetElement(startElement);
            IWebElement target = GenericHelper.GetElement(endElement);
            act.ClickAndHold(start).MoveToElement(target).Release().Build().Perform();
            Thread.Sleep(3000);
        }
    }
}
