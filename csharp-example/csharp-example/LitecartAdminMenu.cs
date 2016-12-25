using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class LitecartAdminMenu : TestBase
    {
        [Test]
        public void AdminMenu()
        {
            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            var menuItemsCount = (Int64)JsExecutor.ExecuteScript("return $('[id=\"app-\"] .icon-wrapper').length");
            for (var m = 0; m < menuItemsCount; m++)
            {
                ((IWebElement)JsExecutor.ExecuteScript("return $('[id=\"app-\"] .icon-wrapper')[" + m + "]")).Click();
                Assert.True(Driver.FindElement(By.TagName("h1")).Displayed);

                var submenuItemsCount = (Int64)JsExecutor.ExecuteScript("return $('[id=\"app-\"] ul li').length");
                for (var s = 0; s < submenuItemsCount; s++)
                {
                    ((IWebElement)JsExecutor.ExecuteScript("return $('[id=\"app-\"] ul li')[" + s + "]")).Click();
                    Assert.True(Driver.FindElement(By.TagName("h1")).Displayed);
                }
            }
        }
    }
}
