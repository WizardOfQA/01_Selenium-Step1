using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class BrowserHelper
    {
        public static void MaxBrowser()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void GoFoward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToFrame(By locator)
        {
            ObjectRepository.Driver.SwitchTo().Frame(GenericHelper.GetElement(locator));
        }
    }
}
