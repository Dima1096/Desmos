Feature: Verify the buttons on the abc tab can be clicked and clear


Scenario: Verify the buttons on the abc tab can be clicked and clear
	Given 'Scientific' page was opened
	Then 'Abc' tab 'is' displayed 
		And 'Main' tab 'is' selected 
	When I click on 'Abc' tab
	Then 'Abc' tab 'is' selected
	When I hover '<command>' keypad button on 'Abc' keypad
	Then '<command>' button 'is' highlighted on 'Abc' keypad
	When I click on '<command>' keypad button on 'Abc' keypad
	Then Text in input field 'is' equal '<text>'
	When I click on 'clear all' button
	Then Text in input field 'is' equal ''

Examples: 
	| command | text |
	| a       | a    |
	| b       | b    |
	| c       | c    |
	| d       | d    |