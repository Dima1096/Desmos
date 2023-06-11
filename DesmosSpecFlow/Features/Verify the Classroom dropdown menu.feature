Feature: Verify the Classroom dropdown menu


Scenario: Verify the Classroom dropdown menu
	Given 'Scientific' page was opened
	Then 'Classroom' dropdown menu 'is' displayed
	When I click on the 'Classroom' dropdown menu
	Then 'Classroom' list 'is' displayed
		And  Following options 'are' displayed in 'Classroom' list
			| Value            |
			| For Teachers     |
			| For Students     |
			| Desmos Math 6–A1 |