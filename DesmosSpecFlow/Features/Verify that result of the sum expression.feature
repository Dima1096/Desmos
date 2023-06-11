Feature: Verify that result of the sum expression


Scenario: Verify that result of the sum expression
	Given 'Scientific' page was opened
	Then 'Main' tab 'is' displayed 
		And 'Main' tab 'is' selected 
		And 'Main' keypad 'is' displayed
	When I click on '<ValueOne>' keypad button on 'Main' keypad
		And I click on '+' keypad button on 'Main' keypad
		And I click on '<ValueTwo>' keypad button on 'Main' keypad
		And I click on 'enter' keypad button on 'Main' keypad
	Then Expression field 'is' added
		And Last expression field 'is' equal '<ValueOne>+<ValueTwo>'
		And Result of last sum expression field is correct
		| ValueOne   | ValueTwo   |
		| <ValueOne> | <ValueTwo> |
		
 
Examples: 
	| ValueOne | ValueTwo |
	| 3        | 5        |