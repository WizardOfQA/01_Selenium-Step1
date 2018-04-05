using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class WindowHelper
    {
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }

        // Switch the window 
        public static void SwitchToWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            if(windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index " + index);
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            BrowserHelper.MaxBrowser();
        }

        // close all the child windows and go back to the parent window.
        public static void SwitchToParent()
        {
            var windowsids = ObjectRepository.Driver.WindowHandles;
            for(int i=windowsids.Count-1; i>0; i--)
            {
                ObjectRepository.Driver.SwitchTo().Window(windowsids[i]);
                ObjectRepository.Driver.Close();
            }
            ObjectRepository.Driver.SwitchTo().Window(windowsids[0]);
        }
    }
}
