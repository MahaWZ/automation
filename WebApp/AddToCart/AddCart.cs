using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.WebApp.AddToCart
{
    class AddCart: CorePage
    {
        public void Add_Cart(string url,string Rname,string Remail,string name,string email, string msg)
        {
            driver.Url = url;

            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[3]/div/div/div[3]/div[2]/div/div[2]/div[3]/div[2]/input")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).SendKeys(Rname);
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).SendKeys(Remail);
            driver.FindElement(By.Id("giftcard_2_SenderName")).SendKeys(name);
            driver.FindElement(By.Id("giftcard_2_SenderEmail")).SendKeys(email);
            driver.FindElement(By.Id("giftcard_2_Message")).SendKeys(msg);
            
        }
    }
}
