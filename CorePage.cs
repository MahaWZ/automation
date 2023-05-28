using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation
{
    public class CorePage
    {
        public static IWebDriver driver;

        public static IWebDriver SeleinuimInit()
        {
            IWebDriver chdriver = new ChromeDriver();
            driver = chdriver;

            return driver;

        }
    }
}
