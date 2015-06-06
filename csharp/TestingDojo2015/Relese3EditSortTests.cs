namespace TestingDojo2015
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    #endregion

    [TestFixture]
    public class Relese3EditSortTests : BaseTestFixture
    {
        #region Public Methods and Operators

        [Test]
        public void EditItem()
        {
            var mainWindow = this.Driver.FindElementById("MainWindow");

            var productsList = mainWindow.FindElement(By.Id("ProductsMW"));
            var firstItem = productsList.FindElements(By.ClassName("ListViewItem")).First();
            var act = new Actions(this.Driver);
            act.DoubleClick(firstItem);
            act.Perform();

            var editWindow = this.Driver.FindElementById("ChangeProductWindow");
            editWindow.FindElement(By.Id("NameCW")).SendKeys("1");
            editWindow.FindElement(By.Id("SaveCW")).Click();

            var result = firstItem.FindElements(By.ClassName("TextBlock")).Last().GetAttribute("Name");

            Assert.That(result, Is.EqualTo("1"));
        }

        [Test]
        public void SortItem()
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
                        var name1 = item1.FindElements(By.ClassName("TextBlock")).Last().GetAttribute("Name");
                        var name2 = item2.FindElements(By.ClassName("TextBlock")).Last().GetAttribute("Name");

                        return String.Compare(name1, name2, StringComparison.Ordinal);
                    });

            for (int i = 0; i < items.Count; i++)
            {
                var name1 = items[i].FindElements(By.ClassName("TextBlock")).Last().GetAttribute("Name");
                var name2 = sortItems[i].FindElements(By.ClassName("TextBlock")).Last().GetAttribute("Name");

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

