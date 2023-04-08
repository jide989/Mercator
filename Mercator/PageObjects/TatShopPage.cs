using CdtTimesheet.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CdtTimesheet.PageObjects
{
    public class TatShopPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string _siteUrl = TestContext.Parameters["SiteUrl"];
        private readonly By _allTimesheetsId = By.CssSelector("td:nth-child(2)");
        public TatShopPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateToShopPage()
        {
            _webDriver.Navigate().GoToUrl(_siteUrl);
        }

        public void ClickHighestPriceItemOnPage()
        {
            IList<IWebElement> allPricesOnPageElements = _webDriver.FindElements(By.CssSelector("span > bdi"));
            IWebElement elementWithHighestPrice = null;
            int highestNumber = int.MinValue;

            foreach (IWebElement element in allPricesOnPageElements)
            {
                string text = element.Text.Replace("£", "");
                int number = int.Parse(text.Replace(".", ""));
                if (number > highestNumber)
                {
                    highestNumber = number;
                    elementWithHighestPrice = element;
                }
            }
            elementWithHighestPrice?.Click();
        }

        public void ClickViewBasketButton(string buttonLabelToClick)
        {
            By viewBasketBtn = By.XPath($"//a[contains(text(), '{buttonLabelToClick}')]");
            _webDriver.WaitForElement(viewBasketBtn, 10);
            _webDriver.FindElement(viewBasketBtn).Click();
        }

        public void ClickAddToBasketButton()
        {
            By addToBasketBtn = By.XPath("//button[contains(text(), 'Add to basket')]");
            _webDriver.WaitForElement(addToBasketBtn, 10);
            _webDriver.FindElement(addToBasketBtn).Click();
        }

        public string GetProductNameInBasket()
        {
            return _webDriver.FindElement(By.CssSelector("td:nth-child(3) > a")).Text;
        }

        public string GetProductPriceInBasket()
        {
            return _webDriver.FindElement(By.CssSelector("td:nth-child(4) > span > bdi")).Text;
        }
    }
}
