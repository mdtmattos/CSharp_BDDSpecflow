Feature: Search by zip code

@UrlCEP
Scenario: Search by zip code
	Given I am on the page to check Zip code
	When I enter a valid zip code
	Then I validate the zip code data

Scenario: Search by invalid zip code
	Given I am on the page to check Zip code
	When I enter a invalid zip code
	Then I validate the return message