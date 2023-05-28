using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation
{
    class LoginPage : CorePage
    {
        public void Login(string url, string Email, string Password)
        {
            driver.Url = url;

            driver.FindElement(By.ClassName("ico-login")).Click();

            driver.FindElement(By.Id("Email")).SendKeys(Email);
            driver.FindElement(By.Id("Password")).SendKeys(Password);
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[5]/input")).Click();

        }
    }
}
