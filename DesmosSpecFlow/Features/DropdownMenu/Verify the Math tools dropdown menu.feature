Feature: Verify the Math tools dropdown menu


Scenario: Verify the Math tools dropdown menu
	Given 'Scientific' page was opened
	Then 'Math tools' dropdown menu 'is' displayed
	When I click on the 'Math tools' dropdown menu
	Then 'Math tools' list 'is' displayed
		And  Following options 'are' displayed in 'Math tools' list
			| Value                                                         |
			| Scientific Calculator                                         |
			| Four-Function Calculator                                      |
			| Test Practice                                                 |
			| Matrix Calculator                                             |
			| Geometry Tool                                                 |
			| Download our apps in the Google Play Store and iOS App Store. |