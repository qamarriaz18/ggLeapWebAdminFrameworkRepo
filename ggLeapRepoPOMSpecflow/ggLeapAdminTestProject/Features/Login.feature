Feature: ggLeapLogin
	Check if login functionality works fine

@smoke @positive
Scenario: Login user as Administrator
	Given user navigates to ggLeap web admin
	When user enters username and password
	And user clicks login button
	Then user should be logged in successfully