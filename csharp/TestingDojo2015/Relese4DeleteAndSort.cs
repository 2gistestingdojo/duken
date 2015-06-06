namespace TestingDojo2015
{
    #region using

    using System;
    using System.Linq;

    using NUnit.Framework;

    using OpenQA.Selenium;

    #endregion

    [TestFixture]
    public class Relese4DeleteAndSort : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void DeleteItem()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var deleteItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            deleteItem.FindElement(By.Id("DeleteMW")).Click();

            var productItems = productsList.FindElements(By.ClassName("ListViewItem"));
            
            
            Assert.That(productItems.Count, Is.EqualTo(7));
        }

        [Test]
        public void AscendingSortItems()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("s");
            searchString.Submit();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var items = productsList.FindElements(By.ClassName("ListViewItem")).ToList();

            var sortItems = productsList.FindElements(By.ClassName("ListViewItem")).ToList(); ;

            sortItems.Sort(delegate(IWebElement item1, IWebElement item2)
            {
                var name1 = item1.FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");
                var name2 = item2.FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");

                return String.Compare(name1, name2, StringComparison.Ordinal);
            });

            for (int i = 0; i < items.Count; i++)
            {
                var name1 = items[i].FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");
                var name2 = sortItems[i].FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");

                if (name1 != name2)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [Test]
        public void DescendingSortItems()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            mainWindow.FindElement(By.Id("SortDownMW")).Click();

            var searchString = mainWindow.FindElement(By.Id("QueryMW"));
            searchString.SendKeys("s");
            searchString.Submit();

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var items = productsList.FindElements(By.ClassName("ListViewItem")).ToList();

            var sortItems = productsList.FindElements(By.ClassName("ListViewItem")).ToList(); ;

            sortItems.Sort(delegate(IWebElement item1, IWebElement item2)
            {
                var name1 = item1.FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");
                var name2 = item2.FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");

                return -String.Compare(name1, name2, StringComparison.Ordinal);
            });

            for (int i = 0; i < items.Count; i++)
            {
                var name1 = items[i].FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");
                var name2 = sortItems[i].FindElements(By.ClassName("TextBlock"))[1].GetAttribute("Name");

                if (name1 != name2)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        #endregion
    }
}
