Feature: Search

@Product_Search
Scenario Outline: Search for products 
	Given User will be on the HomePage
	When User will type the '<searchtext>' in the searchbox
	
	Then search results are loaded in the same page with '<searchtext>'
Examples: 
   | searchtext |
   | water      |    
   | java       |         
   | hairgrass  |         
