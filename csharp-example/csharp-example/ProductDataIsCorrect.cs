using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace csharp_example
{
    public class ProductDataIsCorrect : TestBase
    {
        [Test]
        public void ProductData()
        {
            Driver.Url = "http://localhost/litecart/en/";

            var productOnMainPage = Driver.FindElement(By.XPath("//*[@id='box-campaigns']//li/a[@class='link']"));
            var productUrl = productOnMainPage.GetAttribute("href");
            var productName = productOnMainPage.FindElement(By.XPath("div[@class='name']")).Text;

            var regularPrice = productOnMainPage.FindElement(By.XPath(".//s[@class='regular-price']"));
            var regularPriceText = regularPrice.Text;
            var campaignPrice = productOnMainPage.FindElement(By.XPath(".//strong[@class='campaign-price']"));
            var campaignPriceText = campaignPrice.Text;

            Assert.AreEqual("rgba(119, 119, 119, 1)", regularPrice.GetCssValue("color"));
            Assert.AreEqual("line-through", regularPrice.GetCssValue("text-decoration"));
            Assert.AreEqual("rgba(204, 0, 0, 1)", campaignPrice.GetCssValue("color"));
            Assert.AreEqual("none", campaignPrice.GetCssValue("text-decoration"));

            var regularPriceFontSize = Decimal.Parse(regularPrice.GetCssValue("font-size").Replace("px", ""));
            var campaignPriceFontSize = Decimal.Parse(campaignPrice.GetCssValue("font-size").Replace("px", ""));
            Assert.True(regularPriceFontSize < campaignPriceFontSize);

            productOnMainPage.Click();

            var productPageRegularPrice = Driver.FindElement(By.XPath("//s[@class='regular-price']"));
            var productPageCampaignPrice = Driver.FindElement(By.XPath("//strong[@class='campaign-price']"));

            Assert.AreEqual(productUrl, Driver.Url);
            Assert.AreEqual(productName, Driver.FindElement(By.TagName("h1")).Text);
            Assert.AreEqual(regularPriceText, productPageRegularPrice.Text);
            Assert.AreEqual(campaignPriceText, productPageCampaignPrice.Text);

            Assert.AreEqual("rgba(102, 102, 102, 1)", productPageRegularPrice.GetCssValue("color"));
            Assert.AreEqual("line-through", productPageRegularPrice.GetCssValue("text-decoration"));
            Assert.AreEqual("rgba(204, 0, 0, 1)", productPageCampaignPrice.GetCssValue("color"));
            Assert.AreEqual("none", productPageCampaignPrice.GetCssValue("text-decoration"));

            var productPageRegularPriceFontSize = Decimal.Parse(productPageRegularPrice.GetCssValue("font-size").Replace("px", ""));
            var productPageCampaignPriceFontSize2 = Decimal.Parse(productPageCampaignPrice.GetCssValue("font-size").Replace("px", ""));
            Assert.True(productPageRegularPriceFontSize < productPageCampaignPriceFontSize2);
        }
    }
}
