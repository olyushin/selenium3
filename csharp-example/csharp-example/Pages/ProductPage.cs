using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace csharp_example.Pages
{
    public class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "options[Size]")]
        public IList<IWebElement> Size;

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        public IWebElement AddProduct;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart']//*[@class='quantity']")]
        public IWebElement QuantityOfOrders;

        public void AddProductToCart()
        {
            var initialQuantityOfOrders = Int32.Parse(QuantityOfOrders.Text);
            if (Size.Count > 0)
            {
                SelectSize(1);
            }
            AddProduct.Click();

            Wait.Until(driver => QuantityOfOrders.Text == (initialQuantityOfOrders + 1).ToString());
        }

        public void SelectSize(int index)
        {
            new SelectElement(Size[0]).SelectByIndex(index);
        }
    }
}
