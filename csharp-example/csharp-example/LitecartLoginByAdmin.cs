using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace csharp_example
{
    public class LitecartLoginByAdmin
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginByAdmin()
        {
            _driver.Url = "http://localhost/litecart/admin/";
            _driver.FindElement(By.Name("username")).SendKeys("admin");
            _driver.FindElement(By.Name("password")).SendKeys("admin");
            _driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
