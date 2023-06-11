Feature: Verify the Resources dropdown menu


Scenario: Verify the Resources dropdown menuu
	Given 'Scientific' page was opened
	Then 'Resources' dropdown menu 'is' displayed
	When I click on the 'Resources' dropdown menu
	Then 'Resources' list 'is' displayed
		And  Following options 'are' displayed in 'Resources' list
			| Value              |
			| About Us           |
			| Careers            |
			| Help Center        |
			| Accessibility      |
			| Assessments        |
			| Equity Principles  |
			| Guiding Principles |
			| Desmos Store       |
			| Des-Blog           |