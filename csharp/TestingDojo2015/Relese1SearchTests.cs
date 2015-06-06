namespace TestingDojo2015
{
    #region using

    using NUnit.Framework;

    using OpenQA.Selenium;

    #endregion

    [TestFixture]
    public class SearchTests : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void SearchById()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("3");

            var searchButton = mainWindow.FindElement(By.Id("SearchMW"));
            searchButton.Click();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(1));
        }

        [Test]
        public void SearchByIdSubmit()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("3");
            searchString.Submit();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(1));
        }

        [Test]
        public void SearchByName()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("Монитор");

            var searchButton = mainWindow.FindElement(By.Id("SearchMW"));
            searchButton.Click();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(3));
        }

        [Test]
        public void SearchByNameWithoutReg()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("монитор");

            var searchButton = mainWindow.FindElement(By.Id("SearchMW"));
            searchButton.Click();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(3));
        }

        [Test]
        public void SearchBySubStringName()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("s");

            var searchButton = mainWindow.FindElement(By.Id("SearchMW"));
            searchButton.Click();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(6));
        }

        #endregion
    }
}
