using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class NewCustomerRegistration : TestBase
    {
        [Test]
        public void CustomerRegistration()
        {
            Driver.Url = "http://localhost/litecart/en/";
            Driver.FindElement(By.XPath("//a[contains(text(),'New customers click here')]")).Click();

            Driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys("FirstName");
            Driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys("LastName");
            Driver.FindElement(By.XPath("//input[@name='address1']")).SendKeys("Address1");
            Driver.FindElement(By.XPath("//input[@name='postcode']")).SendKeys("M5P 2N7");
            Driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("NY");

            new SelectElement(Driver.FindElement(By.XPath("//select[@name='country_code']"))).SelectByText("Canada");
            JsExecutor.ExecuteScript("arguments[0].selectedIndex = 2; arguments[0].dispatchEvent(new Event('change'))", Driver.FindElement(By.XPath("//select[@name='zone_code']")));

            var email = (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + "@email.com";
            Driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(email);

            Driver.FindElement(By.XPath("//input[@name='phone']")).SendKeys("111-11-11");
            Driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("password");
            Driver.FindElement(By.XPath("//input[@name='confirmed_password']")).SendKeys("password");
            Driver.FindElement(By.XPath("//button[@name='create_account']")).Click();

            Driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
            Driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(email);
            Driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("password");
            Driver.FindElement(By.XPath("//button[@name='login']")).Click();
        }
    }
}
