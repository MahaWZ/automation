using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.WebApp.SearchPage
{
    class Search : CorePage
    {
        public void Searchs(string url, string item)
        {
            driver.Url = url;
            driver.FindElement(By.Id("small-searchterms")).SendKeys(item);
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[3]/form/input[2]")).Click();
            
        }
    }
}
//keyword