using Microsoft.Win32;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.WebApp.Register
{
    class Register : CorePage
    {
        public void Registration(string url, string FirstName, string LastName, string Email, string Password, string ConfirmPassword)
        {
            driver.Url = url;
            
            driver.FindElement(By.ClassName("ico-register")).Click();
            driver.FindElement(By.Id("gender-male")).Click();
            driver.FindElement(By.Id("FirstName")).SendKeys(FirstName);
            driver.FindElement(By.Id("LastName")).SendKeys(LastName);
            driver.FindElement(By.Id("Email")).SendKeys(Email);
            driver.FindElement(By.Id("Password")).SendKeys(Password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(ConfirmPassword);
            driver.FindElement(By.Id("register-button")).Click();

        }
    }
}
