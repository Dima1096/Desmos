Feature: Verify the buttons on the main tab can be clicked and clear


Scenario: Verify the buttons on the main tab can be clicked and clear
	Given 'Scientific' page was opened
	Then 'Main' tab 'is' displayed 
		And 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed
	When I hover '<command>' keypad button on 'Main' keypad
	Then '<command>' button 'is' highlighted on 'Main' keypad
	When I click on '<command>' keypad button on 'Main' keypad
	Then Text in input field 'is' equal '<text>'
	When I click on 'clear all' button
	Then Text in input field 'is' equal ''

Examples: 
	| command | text |
	| 0       | 0    |
	| 1       | 1    |
	| 2       | 2    |
	| 3       | 3    |
