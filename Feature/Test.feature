Feature: Test feature for Vitality
 
Background:
	Given I am on the homepage

Scenario: Weather Forecast
	When I click accept cookies
	When I click on weather
	And I search 'Bournemouth, Bournemouth'
	And I click on tomorrow date
	Then I assert tomorrow high temperature is greater than the low temperature