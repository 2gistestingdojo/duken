namespace TestingDojo2015
{
    #region using

    using System;
    using System.Linq;

    using NUnit.Framework;

    using OpenQA.Selenium;

    #endregion

    [TestFixture]
    public class Relese5DeleteAndSortExtension : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void AscendingSortItemsById()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var comboBox = mainWindow.FindElement(By.Id("SortByMW"));
            comboBox.Click();
            comboBox.FindElements(By.ClassName("ListBoxItem"))[0].Click();

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("s");
            searchString.Submit();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var items = productsList.FindElements(By.ClassName("ListViewItem")).ToList();

            var sortItems = productsList.FindElements(By.ClassName("ListViewItem")).ToList(); ;

            sortItems.Sort(delegate(IWebElement item1, IWebElement item2)
            {
                var name1 = item1.FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");
                var name2 = item2.FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");

                return String.Compare(name1, name2, StringComparison.Ordinal);
            });

            for (int i = 0; i < items.Count; i++)
            {
                var name1 = items[i].FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");
                var name2 = sortItems[i].FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");

                if (name1 != name2)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [Test]
        public void DescendingSortItemsById()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            mainWindow.FindElement(By.Id("SortDownMW")).Click();

            var comboBox = mainWindow.FindElement(By.Id("SortByMW"));
            comboBox.Click();
            comboBox.FindElements(By.ClassName("ListBoxItem"))[0].Click();

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("s");
            searchString.Submit();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var items = productsList.FindElements(By.ClassName("ListViewItem")).ToList();

            var sortItems = productsList.FindElements(By.ClassName("ListViewItem")).ToList(); ;

            sortItems.Sort(delegate(IWebElement item1, IWebElement item2)
            {
                var name1 = item1.FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");
                var name2 = item2.FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");

                return -String.Compare(name1, name2, StringComparison.Ordinal);
            });

            for (int i = 0; i < items.Count; i++)
            {
                var name1 = items[i].FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");
                var name2 = sortItems[i].FindElements(By.ClassName("TextBlock"))[0].GetAttribute("Name");

                if (name1 != name2)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [Test]
        public void ManyDeleteItemsCtrl()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");


            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            this.Driver.ExecuteScript("input: ctrl_click", productItems.First());
            this.Driver.ExecuteScript("input: ctrl_click", productItems.Last());

            var addButton = mainWindow.FindElement(By.Id("AddNewProductMW"));
            addButton.Click();

            productItems = productsList.FindElements(By.ClassName("ListViewItem"));

            Assert.That(productItems.Count, Is.EqualTo(6));
        }

        #endregion
    }
}
