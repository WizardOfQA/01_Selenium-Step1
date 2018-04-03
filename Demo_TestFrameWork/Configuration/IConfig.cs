using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.Configuration
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUserName();
        string GetPassword();
        string GetWebSite();
        string GetScreenshotStorage();
        int GetPageLoadTimeout();
        int GetElementTimeout();
    }
}
