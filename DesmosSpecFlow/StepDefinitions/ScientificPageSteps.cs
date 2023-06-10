﻿using Aquality.Selenium.Browsers;
using DesmosTest.Configurations;
using DesmosTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DesmosSpecFlow.StepDefinitions
{

	[Binding]
	public class ScientificPageSteps
	{
		private readonly ScenarioContext _scenarioContext;

		private readonly ScientificPage _scientificPage;
		public ScientificPageSteps(ScenarioContext scenarioContext) 
		{
			_scenarioContext = scenarioContext;
			_scientificPage = new ScientificPage();
		}


		[Given(@"'Scientific' page was opened")]
		public void PageScientificWasOpened()
		{
			AqualityServices.Browser.GoTo(Configuration.StartUrl);
			Assert.IsTrue(_scientificPage.State.WaitForDisplayed(), "_scientificPage page is not opened!");
		}

		[Then(@"'Math tools' dropdown menu '(is|is not)' displayed")]
		public void CheckMathToolsDropdownMenuIsDisplayed(bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.MathToolsMenu), 
			$"'MathToolsMenu' is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[When(@"I click on the 'Math tools' dropdown menu")]
		public void ClickOnMathToolsDropdownMenu() => _scientificPage.ClickToElement(ScientificPage.ScientificItems.MathToolsMenu);

		[Then(@"'Math tools' list '(is|is not)' displayed")]
		public void CheckMathToolsListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.MathToolsList);
			}),
			$"Math tools is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"Following options '(are|are not)' displayed in 'Math tools' list")]
		public void CheckListContainsFollowingOptions(bool isDisplayed, Table table) => Assert.Multiple(() =>
		{
			foreach (var row in table.Rows)
			{
				Assert.AreEqual(isDisplayed, _scientificPage.GetListOfMathToolsItems().Contains(row[0]),
						$"{row[0]} option is {(isDisplayed ? " not" : string.Empty)} displayed!");
			}
		});


	}
}