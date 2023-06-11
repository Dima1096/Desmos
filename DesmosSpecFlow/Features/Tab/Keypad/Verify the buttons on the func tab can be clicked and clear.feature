Feature: Verify the buttons on the func tab can be clicked and clear


Scenario: Verify the buttons on the func tab can be clicked and clear
	Given 'Scientific' page was opened
	Then 'Func' tab 'is' displayed 
		And 'Main' tab 'is' selected 
	When I click on 'Func' tab
	Then 'Func' tab 'is' selected
	When I hover '<command>' keypad button on 'Func' keypad
	Then '<command>' button 'is' highlighted on 'Func' keypad
	When I click on '<command>' keypad button on 'Func' keypad
	Then Text in input field 'is' equal '<text>'
	When I click on 'clear all' button
	Then Text in input field 'is' equal ''

Examples: 
	| command | text |
	| sin     | sin  |
	| cos     | cos  |
	| tan     | tan  |