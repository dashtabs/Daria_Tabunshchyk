Feature: 4. Delete Job
	Delete a job you've just created
	Background: 
	Given I am already logged in 
	And I have navigated to page https://opensource-demo.orangehrmlive.com/index.php/admin/viewJobTitleList

	@ScAdd
	Scenario: Delete a job succesfully
		Given I click on the checkbox of Student element
		And I click Delete
		When I click OK
		Then The element with the title Student should be deleted