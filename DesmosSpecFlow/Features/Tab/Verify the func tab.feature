Feature: Verify the func tab


Scenario: Verify the func tab
	Given 'Scientific' page was opened
	Then 'Func' tab 'is' displayed 
		And 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed
	When I hover 'Func' tab
	Then 'Func' tab 'is' highlighted
	When I click on 'Func' tab
	Then 'Main' tab 'is not' selected 
		And 'Main' keypad 'is not' displayed
		And 'Func' tab 'is' selected 
		And 'Func' keypad 'is' displayed