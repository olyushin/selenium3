using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class GeoZonesAreSorted : TestBase
    {
        [Test]
        public void GeoZones()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            Driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";

            var countries = Driver.FindElements(By.XPath("//*[@class='row']/td[3]/a[not(@title)]")).Select(_ => _.GetAttribute("href")).ToList();
            foreach (var country in countries)
            {
                Driver.Url = country;

                var unsortedZones = Driver.FindElements(By.XPath("//*[contains(@name,'[zone_code]')]/*[@selected]")).Select(_ => _.Text).ToList();
                var sortedZones = unsortedZones.OrderBy(_ => _);
                Assert.AreEqual(sortedZones, unsortedZones);
            }
        }
    }
}
