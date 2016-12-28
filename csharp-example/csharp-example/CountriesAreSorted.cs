using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class CountriesAreSorted : TestBase
    {
        [Test]
        public void Countries()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            Driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            var unsortedCountries = Driver.FindElements(By.XPath("//*[@class='row']/td[5]")).Select(_ => _.Text).ToList();
            var sortedCountries = unsortedCountries.OrderBy(_ => _);
            Assert.AreEqual(sortedCountries, unsortedCountries);

            var countriesWithZones = Driver.FindElements(By.XPath("//*[@class='row']/td[6][not(text()='0')]/../td/a[not(@title)]")).Select(_ => _.GetAttribute("href")).ToList();
            foreach (var zone in countriesWithZones)
            {
                Driver.Url = zone;

                var unsortedZones = Driver.FindElements(By.XPath("//*[@id='table-zones']//td[3]/input[contains(@name,'zones')]")).Select(_ => _.GetAttribute("value")).ToList();
                var sortedZones = unsortedZones.OrderBy(_ => _);
                Assert.AreEqual(sortedZones, unsortedZones);
            }
        }
    }
}
