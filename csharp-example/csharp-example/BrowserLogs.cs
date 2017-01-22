using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class BrowserLogs : TestBase
    {
        [Test]
        public void Logs()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            Driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

            var productsLinks = Driver.FindElements(By.XPath("//*[@class='row']//img/../a")).Select(_ => _.GetAttribute("href")).ToList();
            foreach (var link in productsLinks)
            {
                Driver.Url = link;

                Assert.AreEqual(0, Driver.Manage().Logs.GetLog("browser").Count);
            }
        }
    }
}
