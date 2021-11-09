Feature: ggLeapNewUserCreation
	Check if add new user functionality works fine

@smoke @positive
Scenario: Create new User
	Given user navigates to ggLeap webAdmin
	When user enter username and password
	And user click login button
	Then user should login successfully
	When user clicks on Users from left menu bar
	Then Users page should be opened successfully
	When user clicks Add User button
	And user input data to create a new user
	Then new user should be created successfully
	When user clicks button to expand search section
	And user input username
	Then user should be able to retrieve user
	When user input email in search field
	Then user should be able to retrieve user successfully