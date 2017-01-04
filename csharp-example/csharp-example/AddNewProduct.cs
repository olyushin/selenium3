using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class AddNewProduct: TestBase
    {
        [Test]
        public void NewProduct()
        {
            Driver.Url = "http://localhost/litecart/admin/";

            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();

            Driver.FindElements(By.XPath("//span[@class='name']")).First(_ => _.Text == "Catalog").Click();
            Driver.FindElement(By.XPath("//a[contains(text(),'Add New Product')]")).Click();
            
            Driver.FindElement(By.XPath("//label[contains(text(),'Enabled')]//input[@name='status']")).Click();
            var name = (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Driver.FindElement(By.Name("name[en]")).SendKeys("Name " + name);
            Driver.FindElement(By.Name("code")).SendKeys("Code");
            Driver.FindElement(By.XPath("//input[@name='categories[]' and @data-name='Rubber Ducks']")).Click();
            Driver.FindElement(By.XPath("//*[contains(text(),'Female')]/..//input[@name='product_groups[]']")).Click();
            Driver.FindElement(By.Name("quantity")).Clear();
            Driver.FindElement(By.Name("quantity")).SendKeys("11");
            var pathToImage = Path.Combine(Environment.CurrentDirectory, "YellowDuck.png");
            Driver.FindElement(By.Name("new_images[]")).SendKeys(pathToImage);
            Driver.FindElement(By.Name("date_valid_from")).SendKeys(Keys.Home + "01022017");
            Driver.FindElement(By.Name("date_valid_to")).SendKeys(Keys.Home + "01202017");

            Driver.FindElement(By.XPath("//a[contains(text(),'Information')]")).Click();
            new SelectElement(Driver.FindElement(By.XPath("//select[@name='manufacturer_id']"))).SelectByText("ACME Corp.");
            Driver.FindElement(By.Name("keywords")).SendKeys("Keywords");
            Driver.FindElement(By.Name("short_description[en]")).SendKeys("ShortDescription");
            Driver.FindElement(By.XPath("//*[@class='trumbowyg-editor']")).SendKeys("Description");
            Driver.FindElement(By.Name("head_title[en]")).SendKeys("HeadTitle");
            Driver.FindElement(By.Name("meta_description[en]")).SendKeys("MetaDescription");

            Driver.FindElement(By.XPath("//a[contains(text(),'Prices')]")).Click();
            Driver.FindElement(By.Name("purchase_price")).Clear();
            Driver.FindElement(By.Name("purchase_price")).SendKeys("33");
            new SelectElement(Driver.FindElement(By.XPath("//select[@name='purchase_price_currency_code']"))).SelectByText("Euros");
            Driver.FindElement(By.Name("prices[EUR]")).SendKeys("22");

            Driver.FindElement(By.Name("save")).Click();

            Assert.True(Driver.FindElements(By.XPath("//*[@class='row']//a[not(@title)]")).Any(_ => _.Text == "Name " + name));
        }
    }
}
