namespace TestingDojo2015
{
    #region using

    using System.Linq;

    using NUnit.Framework;

    using OpenQA.Selenium;

    #endregion

    [TestFixture]
    public class Relese2AddTests : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void AddNewItem()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();
            

            var addNewItemWindow = this.Driver.FindElementById("AddNewProductWindow");

            var addQuery = addNewItemWindow.FindElement(By.Id("NameAW"));
            addQuery.SendKeys("new Item");

            addNewItemWindow.FindElement(By.Id("AddAW")).Click();


            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(9));
        }

        [Test]
        public void NewItemIdIsMaxPlusOne()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();


            var addNewItemWindow = this.Driver.FindElementById("AddNewProductWindow");

            var addQuery = addNewItemWindow.FindElement(By.Id("NameAW"));
            addQuery.SendKeys("new Item");

            addNewItemWindow.FindElement(By.Id("AddAW")).Click();


            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            var row = productItems.Last().FindElements(By.ClassName("TextBlock"));
            
            Assert.That(row.First().GetAttribute("Name"), Is.EqualTo("9"));
        }


        [Test]
        public void NewItemCancel()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();


            var addNewItemWindow = this.Driver.FindElementById("AddNewProductWindow");

            var addQuery = addNewItemWindow.FindElement(By.Id("NameAW"));
            addQuery.SendKeys("new Item");

            addNewItemWindow.FindElement(By.Id("CancelAW")).Click();


            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(8));
        }



        #endregion
    }
}
