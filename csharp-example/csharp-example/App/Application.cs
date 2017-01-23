using System;
using csharp_example.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace csharp_example.App
{
    public class Application
    {
        public IWebDriver Driver;

        public MainPage MainPage;
        public ProductPage ProductPage;
        public CartPage CartPage;

        public Application()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            MainPage = new MainPage(Driver);
            ProductPage = new ProductPage(Driver);
            CartPage = new CartPage(Driver);
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
