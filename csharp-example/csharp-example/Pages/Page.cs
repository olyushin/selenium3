using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp_example.Pages
{
    public class Page
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;

        public Page(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
