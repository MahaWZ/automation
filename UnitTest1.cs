using automation.WebApp.AddToCart;
using automation.WebApp.Register;
using automation.WebApp.SearchPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace automation
{
    [TestClass]
    public class UnitTest1
    {
        //IWebDriver driver = new ChromeDriver();
        LoginPage log = new LoginPage();
        Register reg = new Register();
        Search ser = new Search();
        AddCart add= new AddCart();

        [TestMethod]
        public void Login_TC01() 
        {
            CorePage.SeleinuimInit();
            log.Login("https://demowebshop.tricentis.com", "mahazamir09@gmail.com", "stproject1");
            bool logout = CorePage.driver.FindElement(By.ClassName("ico-logout")).Displayed;
            Assert.IsTrue(logout);
            CorePage.driver.FindElement(By.ClassName("ico-logout")).Click();

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Login_TC02()
        {
            CorePage.SeleinuimInit();
            log.Login("https://demowebshop.tricentis.com", "mahazamir09@gmail.com", "invalid");
            string expectedText = "Login was unsuccessful. Please correct the errors and try again.";
            bool isTextPresent = CorePage.driver.FindElement(By.XPath($"//*[contains(text(),'{expectedText}')]")).Displayed;
            Assert.IsTrue(isTextPresent, $"The text is not present on the page.");

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Login_TC03()
        {
            CorePage.SeleinuimInit();
            log.Login("https://demowebshop.tricentis.com", "", "");
            string expectedText = "Login was unsuccessful. Please correct the errors and try again.";
            bool isTextPresent = CorePage.driver.FindElement(By.XPath($"//*[contains(text(),'{expectedText}')]")).Displayed;
            Assert.IsTrue(isTextPresent, $"The text is not present on the page.");

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Register_TC01()
        {//already exist
            CorePage.SeleinuimInit();
            reg.Registration("https://demowebshop.tricentis.com","zavi","zam", "zavzamir@gmail.com", "stproject2", "stproject2");
            bool regist = CorePage.driver.FindElement(By.ClassName("ico-logout")).Displayed;
            Assert.IsTrue(regist);
            CorePage.driver.FindElement(By.ClassName("ico-logout")).Click();

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Register_TC02()
        {//new
            CorePage.SeleinuimInit();
            reg.Registration("https://demowebshop.tricentis.com", "amir", "imam", "amir@gmail.com", "stproject3", "stproject3");
            bool regist = CorePage.driver.FindElement(By.ClassName("ico-logout")).Displayed;
            Assert.IsTrue(regist);
            CorePage.driver.FindElement(By.ClassName("ico-logout")).Click();

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Register_TC03()
        {//taken pass and name
            CorePage.SeleinuimInit();
            reg.Registration("https://demowebshop.tricentis.com", "zavi", "zam", "zav@gmail.com", "stproject2", "stproject2");
            bool regist = CorePage.driver.FindElement(By.ClassName("ico-logout")).Displayed;
            Assert.IsTrue(regist);
            CorePage.driver.FindElement(By.ClassName("ico-logout")).Click();

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Search_TC01()
        {
            CorePage.SeleinuimInit();
            ser.Searchs("https://demowebshop.tricentis.com", "health");
            _ = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(100));
            IReadOnlyCollection<IWebElement> items= CorePage.driver.FindElements(By.ClassName("item-box"));
            int check = items.Count;
            Assert.AreEqual(1, check, "The count of displayed products is not as expected.");

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Search_TC02()
        {
            CorePage.SeleinuimInit();
            ser.Searchs("https://demowebshop.tricentis.com", "HE");
            string expectedText = "Search term minimum length is 3 characters";
            bool isTextPresent = CorePage.driver.FindElement(By.XPath($"//*[contains(text(),'{expectedText}')]")).Displayed;
            Assert.IsTrue(isTextPresent, $"The text is not present on the page.");
           _ = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(100));

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Search_TC03()
        {
            CorePage.SeleinuimInit();
            ser.Searchs("https://demowebshop.tricentis.com", "HEX");
            string expectedText = "No products were found that matched your criteria.";
            bool isTextPresent = CorePage.driver.FindElement(By.XPath($"//*[contains(text(),'{expectedText}')]")).Displayed;
            Assert.IsTrue(isTextPresent, $"The text is not present on the page.");
            _ = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(100));

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Search_TC04()
        {
            CorePage.SeleinuimInit();
            ser.Searchs("https://demowebshop.tricentis.com", "");
            IAlert alert = CorePage.driver.SwitchTo().Alert();
            string alertMessage = alert.Text;
            Console.WriteLine("Alert Message: " + alertMessage);
            alert.Accept();

           CorePage.driver.Close();
        }
        [TestMethod]
        public void Add_TC01()
        {
            
            CorePage.SeleinuimInit();
            add.Add_Cart("https://demowebshop.tricentis.com", "ali", "ali@gmail.com", "maha zamir", "mahazamir09@gmail.com", "hi");
            CorePage.driver.FindElement(By.Id("add-to-cart-button-2")).Click();

            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(30));
            bool isDisplayed = wait.Until(driver => driver.FindElement(By.LinkText("shopping cart"))).Displayed;
            Assert.IsTrue(isDisplayed, "The notification is not displayed.");

            CorePage.driver.Close();
        }
        [TestMethod]
        public void Add_TC02()
        {

            CorePage.SeleinuimInit();
            add.Add_Cart("https://demowebshop.tricentis.com", "ali", "ali@gmail.com", "maha zamir", "mahazamir09@gmail.com", "hi");
            CorePage.driver.FindElement(By.Id("add-to-cart-button-2")).Click();
            CorePage.driver.FindElement(By.ClassName("ico-cart")).Click();

            CorePage.driver.Close();
        }

    }
}

