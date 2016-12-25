using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class TestBase
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;
        public IJavaScriptExecutor JsExecutor;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            JsExecutor = (IJavaScriptExecutor)Driver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}
