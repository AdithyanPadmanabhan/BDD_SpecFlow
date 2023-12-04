Feature: SearchAndAddToCart

@E2E-Search_AddtoCart
Scenario: Search
	Given User will be on the HomePage
	When User will type the '<searchtext>' in the searchbox
	Then search results are loaded in the same page with '<searchtext>'
