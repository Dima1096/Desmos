Feature: Verify the main tab


Scenario: Verify the main tab
	Given 'Scientific' page was opened
	Then 'Main' tab 'is' displayed 
		And 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed
	When I click on 'abc' tab
	Then 'Main' tab 'is not' selected 
		And 'Main' keypad 'is not' displayed
		And 'Abc' tab 'is' selected 
		And 'Abc' keypad 'is' displayed
	When  I hover 'Main' tab
	Then  'Main' tab 'is' highlighted
	When I click on 'Main' tab
	Then 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed