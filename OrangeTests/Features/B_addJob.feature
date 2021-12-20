Feature: 2. Add Job
	Create a new job in the corresponding window
	Background: 
	Given I am logged in
	And I navigated to page https://opensource-demo.orangehrmlive.com/index.php/admin/viewJobTitleList

	@ScAdd
	Scenario: Succesfully added a new job
		Given I click the Add button
		And I enter the title Student
		And I enter the description Eat, sleep, study, repeat.
		And I enter the note Pls try not to die in the proccess
		When I click Save button
		Then The element with the title Student should be visible
