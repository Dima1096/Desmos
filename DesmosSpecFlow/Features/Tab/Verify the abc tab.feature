Feature: Verify the abc tab


Scenario: Verify the main tab
	Given 'Scientific' page was opened
	Then 'Abc' tab 'is' displayed 
		And 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed
	When I hover 'Abc' tab
	Then 'Abc' tab 'is' highlighted
	When I click on 'Abc' tab
	Then 'Main' tab 'is not' selected 
		And 'Main' keypad 'is not' displayed
		And 'Abc' tab 'is' selected 
		And 'Abc' keypad 'is' displayed
