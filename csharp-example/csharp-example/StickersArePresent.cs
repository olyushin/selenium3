using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class StickersArePresent : TestBase
    {
        [Test]
        public void Stickers()
        {
            Driver.Url = "http://localhost/litecart/en/";

            var products = Driver.FindElements(By.CssSelector(".product"));

            foreach (var product in products)
            {
                Assert.AreEqual(1, product.FindElements(By.CssSelector(".sticker")).Count);
            }
        }
    }
}
