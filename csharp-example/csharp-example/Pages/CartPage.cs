using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace csharp_example.Pages
{
    public class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "remove_cart_item")]
        public IWebElement RemoveButton;

        [FindsBy(How = How.XPath, Using = "//td[@class='item']")]
        public IList<IWebElement> Orders;

        public void RemoveAllOrders()
        {
            var initialOrdersCount = Orders.Count;
            for (var i = 0; i < initialOrdersCount; i++)
            {
                var ordersTable = Driver.FindElement(By.XPath("//table[@class='dataTable rounded-corners']"));
                Wait.Until(ExpectedConditions.ElementToBeClickable(RemoveButton));
                RemoveButton.Click();
                Wait.Until(ExpectedConditions.StalenessOf(ordersTable));
            }

            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//em"), "There are no items in your cart."));
        }
    }
}
