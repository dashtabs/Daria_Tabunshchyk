Feature: 3. Edit Job
	Create a new job in the corresponding window
	Background: 
	Given I have logged in
	And I navigate to page https://opensource-demo.orangehrmlive.com/index.php/admin/viewJobTitleList

	@ScAdd
	Scenario: Succesfully edited a job
		Given I click on the name
		And I click Edit
		And I clear the description
		And I write the description Sleepy
		When I click Save
		Then The element Student with the description Sleepy should be visible