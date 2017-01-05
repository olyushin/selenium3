using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class CartTests : TestBase
    {
        [Test]
        public void Cart()
        {
            for (var i = 1; i < 4; i++)
            {
                Driver.Url = "http://localhost/litecart/en/";

                Driver.FindElement(By.XPath("//*[@id='box-most-popular']//a[@class='link']")).Click();

                if ((Int64)JsExecutor.ExecuteScript("return $('[name=\"options[Size]\"]').length") > 0)
                {
                    new SelectElement(Driver.FindElement(By.Name("options[Size]"))).SelectByIndex(1);
                }
                Driver.FindElement(By.Name("add_cart_product")).Click();
                Wait.Until(_ => _.FindElement(By.XPath("//*[@id='cart']//*[@class='quantity']")).Text == i.ToString());
            }

            Driver.FindElement(By.XPath("//*[@id='cart']/a[@class='link']")).Click();

            var ordersCount = Driver.FindElements(By.XPath("//td[@class='item']")).Count;
            for (var i = 0; i < ordersCount; i++)
            {
                var orders = Driver.FindElement(By.XPath("//table[@class='dataTable rounded-corners']"));
                Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(By.Name("remove_cart_item"))));
                Driver.FindElement(By.Name("remove_cart_item")).Click();
                Wait.Until(ExpectedConditions.StalenessOf(orders));
            }

            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//em"), "There are no items in your cart."));
        }
    }
}
