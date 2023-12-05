Feature: SearchAndAddToCart

@E2E-Search_AddtoCart
Scenario: Search & Add to Cart
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search Results are loaded in the same page with '<searchtext>'
	* Heading should have '<searchtext>'
	* Title should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page '<searchtext>' is loaded
Examples:
	| searchtext | productno |
	| Water      | 1	|
	| Java	     | 1	|

 #@E2E-Search_AddtoCart
 #Scenario Outline:02 Check-For-Title-After-Search
 #  Given Search page is loaded
 #  When user selects a '<productno>'
 #  Then Product page is loaded
 # Examples: 
 #| productno |
 #| 1    |
