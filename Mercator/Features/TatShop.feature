Feature: TatShop

As a Tat Shop Customer, I would like to add items to basket
So that I can complete a purchase

Background: 
Given I have navigated to Tat Shop

Scenario: Add Highest Priced item on Shop Page to basket
	When I add the highest priced item on the page to basket
	And I click on "View basket" button
	Then "HAPPY NINJA" item with price "35.00" is in basket

