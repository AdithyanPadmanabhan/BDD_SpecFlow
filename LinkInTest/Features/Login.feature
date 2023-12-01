Feature: Login
User logs in with valid credentials(username, password)
the home page will load after successful login


Background: 
    Given User will be on the login page
@positive
Scenario Outline: Login with Valid Credentials
	When user will enter username '<Username>'
	And user will enter password '<Password>'
	And user will click on login button
	Then user will be redirected to Homepage
Examples: 
    | Username    | Password |
    | abc@xy.com | 12345    |
	| sd@xy.com  | 09876    |


	@negative
Scenario Outline: Login with InValid Credentials
	When user will enter username '<Username>'
	And user will enter password '<Password>'
	And user will click on login button
	Then Error message for password length should be thrown
Examples: 
    | Username    | Password |
    | abc@xy.com  | 12345    |
	| sd@xy.com   | 09876    |
   

@regression
Scenario Outline: Check for password hidden display
	When user will enter password '<Password>'
	And user will click on show link  in the password textbox
	Then the password characters should be shown
Examples: 
   | Password |
   | 12345    |
   | 09876    |
	
@regression
Scenario Outline: Check for password show display
	When user will enter password '<Password>'
	And user will click on show link  in the password textbox
	And user will click on hide link  in the password textbox
	Then the password characters should not be shown
Examples: 
   | Password |
   | 12345 |
   | 09876 |