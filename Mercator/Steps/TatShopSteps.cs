using CdtTimesheet.PageObjects;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace Mercator.Steps
{
    [Binding]
    public class TatShopSteps
    {
        private readonly TatShopPage _tatShopPage;

        public TatShopSteps(TatShopPage tatShopPage)
        {
            _tatShopPage = tatShopPage;
        }

        [Given(@"I have navigated to Tat Shop")]
        public void GivenIHaveNavigatedToTatShop()
        {
            _tatShopPage.NavigateToShopPage();
        }

        [When(@"I click on ""([^""]*)"" button")]
        public void WhenIClickOnButton(string buttonName)
        {
            _tatShopPage.ClickViewBasketButton(buttonName);
        }

        [Then(@"""([^""]*)"" item with price ""([^""]*)"" is in basket")]
        public void ThenItemWithPriceIsInBasket(string productName, string productPrice)
        {
            _tatShopPage.GetProductNameInBasket().ToLower().Should().Contain(productName.ToLower());
            _tatShopPage.GetProductPriceInBasket().Should().Contain(productPrice);
        }

        [When(@"I add the highest priced item on the page to basket")]
        public void WhenIAddTheHighestPricedItemOnThePageToBasket()
        {
            _tatShopPage.ClickHighestPriceItemOnPage();
            _tatShopPage.ClickAddToBasketButton();
        }
    }
}
