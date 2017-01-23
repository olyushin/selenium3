using NUnit.Framework;

namespace csharp_example.Tests
{
    public class CartTests : CartTestBase
    {
        [Test]
        public void Cart()
        {
            for (var i = 1; i < 4; i++)
            {
                App.MainPage.OpenMainPage();

                App.MainPage.FirstProductLink.Click();

                App.ProductPage.AddProductToCart();
            }

            App.MainPage.CartLink.Click();

            App.CartPage.RemoveAllOrders();
        }
    }
}
