Feature: 1. Logging in
I log in to the https://opensource-demo.orangehrmlive.com/ site

Background: 
	Given I go to url
@ScLogin
Scenario: I successfully login to a page
	Given The login is Admin
	And The password is admin123
	When I press LOGIN
	Then The link should be https://opensource-demo.orangehrmlive.com/index.php/dashboard

@ScLogin
Scenario: An error logging in
	Given The login is Blah
	And The password is blahblah
	When I press LOGIN
	Then I shoud see Invalid creditenals