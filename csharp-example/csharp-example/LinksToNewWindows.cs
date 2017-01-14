using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class LinksToNewWindows : TestBase
    {
        [Test]
        public void NewWindows()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            Driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            Driver.FindElement(By.XPath("//*[@class='row']/td[7]")).Click();

            var externalLinks = Driver.FindElements(By.XPath("//i[@class='fa fa-external-link']"));

            var mainWindow = Driver.CurrentWindowHandle;

            foreach (var link in externalLinks)
            {
                link.Click();
                Wait.Until(_ => _.WindowHandles.Count == 2);

                var newWindow = Driver.WindowHandles.Single(_ => !_.Contains(mainWindow));
                Driver.SwitchTo().Window(newWindow);
                Driver.Close();
                Driver.SwitchTo().Window(mainWindow);
            }
        }
    }
}
