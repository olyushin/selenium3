using csharp_example.App;
using NUnit.Framework;

namespace csharp_example.Tests
{
    public class CartTestBase
    {
        public Application App;

        [SetUp]
        public void SetUp()
        {
            App = new Application();
        }

        [TearDown]
        public void TearDown()
        {
            App.Quit();
            App = null;
        }
    }
}
