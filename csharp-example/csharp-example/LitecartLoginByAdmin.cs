using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class LitecartLoginByAdmin : TestBase
    {
        [Test]
        public void LoginByAdmin()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();
        }
    }
}
