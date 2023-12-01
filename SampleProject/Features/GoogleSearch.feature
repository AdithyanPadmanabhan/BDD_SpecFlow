Feature: GoogleSearch

to perform search operation on google home page

@tag1
Scenario: To Perform search with google search button 
	Given Google home page should be loaded
	When Type "hp laptop" in the search text input
	And Click on the Google Search button
    Then the results should be displayed on the next page with title "hp laptop - Google Search"

Scenario: To Perform search with IMF button 
	Given Google home page should be loaded
	When Type "hp laptop" in the search text input
	And Click on the IMF button
    Then the results should be redirected to a new page with title "HP Laptops"
