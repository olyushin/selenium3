using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace csharp_example.Pages
{
    public class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='cart']/a[@class='link']")]
        public IWebElement CartLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='box-most-popular']//a[@class='link']")]
        public IWebElement FirstProductLink;

        public void OpenMainPage()
        {
            Driver.Url = "http://localhost/litecart/en/";
        }
    }
}
