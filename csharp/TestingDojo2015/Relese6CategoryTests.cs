namespace TestingDojo2015
{
    #region using

    using System;
    using System.Linq;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    #endregion

    [TestFixture]
    public class Relese6CategoryTests : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void AddNewItemCat()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();

            var addNewItemWindow = this.Driver.FindElementById("AddNewProductWindow");

            var addQuery = addNewItemWindow.FindElement(By.Id("NameAW"));
            addQuery.SendKeys("new Item");

            var comboBox = addNewItemWindow.FindElement(By.Id("CategoryAW"));
            comboBox.Click();

            comboBox.FindElements(By.ClassName("ListBoxItem"))[1].Click();

            addNewItemWindow.FindElement(By.Id("AddAW")).Click();


            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItem = productsList.FindElements(By.ClassName("ListViewItem")).First(x => x.FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name") == "9");
            var nameCat = productItem.FindElements(By.ClassName("TextBlock"))[2].GetAttribute("Name");

            Assert.That(nameCat, Is.EqualTo("Сетевое оборудование"));
        }

        [Test]
        public void EditItemCat()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var firstItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            var act = new Actions(this.Driver);
            act.DoubleClick(firstItem);
            act.Perform();

            var editWindow = this.Driver.FindElementById("ChangeProductWindow");
            var comboBox = editWindow.FindElement(By.Id("CategoryCW"));
            comboBox.Click();

            comboBox.FindElements(By.ClassName("ListBoxItem"))[1].Click();
            editWindow.FindElement(By.Id("SaveCW")).Click();

            firstItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            var result = firstItem.FindElements(By.ClassName("TextBlock"))[2].GetAttribute("Name");

            Assert.That(result, Is.EqualTo("Сетевое оборудование"));
        }

        [Test]
        public void EditItemCatCancel()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var firstItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            var act = new Actions(this.Driver);
            act.DoubleClick(firstItem);
            act.Perform();

            var editWindow = this.Driver.FindElementById("ChangeProductWindow");
            var comboBox = editWindow.FindElement(By.Id("CategoryCW"));
            comboBox.Click();

            comboBox.FindElements(By.ClassName("ListBoxItem"))[1].Click();
            editWindow.FindElement(By.Id("CancelCW")).Click();

            firstItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            var result = firstItem.FindElements(By.ClassName("TextBlock"))[2].GetAttribute("Name");

            Assert.That(result, Is.EqualTo("Периферия"));
        }

        [Test]
        public void AddNewItemCatCancel()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();

            var addNewItemWindow = this.Driver.FindElementById("AddNewProductWindow");

            var addQuery = addNewItemWindow.FindElement(By.Id("NameAW"));
            addQuery.SendKeys("new Item");

            var comboBox = addNewItemWindow.FindElement(By.Id("CategoryAW"));
            comboBox.Click();

            comboBox.FindElements(By.ClassName("ListBoxItem"))[1].Click();

            addNewItemWindow.FindElement(By.Id("CancelAW")).Click();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItem = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItem.Count, Is.EqualTo(8));
        }

        #endregion
    }
}
