using Aquality.Selenium.Browsers;
using DesmosTest.Configurations;
using DesmosTest.Pages;
using ICSharpCode.SharpZipLib;
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
			$"'Math tools' list is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"Following options '(are|are not)' displayed in 'Math tools' list")]
		public void CheckListContainsFollowingOptions(bool isDisplayed, Table table) => Assert.Multiple(() =>
		{
			foreach (var row in table.Rows)
			{
				Assert.AreEqual(isDisplayed, _scientificPage.GetListOfMathToolsItems().Contains(row[0]),
						$"{row[0]} option is {(isDisplayed ? " not" : string.Empty)} displayed in 'Math tools' list!");
			}
		});

		[Then(@"'Classroom' dropdown menu '(is|is not)' displayed")]
		public void CheckClassroomDropdownMenuIsDisplayed(bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.ClassroomMenu),
		   $"'Classroom' is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[When(@"I click on the 'Classroom' dropdown menu")]
		public void ClickOnClassroomDropdownMenu() => _scientificPage.ClickToElement(ScientificPage.ScientificItems.ClassroomMenu);

		[Then(@"'Classroom' list '(is|is not)' displayed")]
		public void CheckClassroomListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.ClassroomList);
			}),
				$"'Classroom' list is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"Following options '(are|are not)' displayed in 'Classroom' list")]
		public void CheckFollowingOptionsIsDisplayedInClassroomList(bool isDisplayed, Table table) => Assert.Multiple(() =>
		{
			foreach (var row in table.Rows)
			{
				Assert.AreEqual(isDisplayed, _scientificPage.GetListOfClassroomItems().Contains(row[0]),
						$"{row[0]} option is {(isDisplayed ? " not" : string.Empty)} displayed in 'Classroom' list!");
			}
		});

		[Then(@"'Resources' dropdown menu '(is|is not)' displayed")]
		public void CheckResourcesDropdownMenuIsDisplayed(bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.ResourcesMenu),
			$"'Resources' is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[When(@"I click on the 'Resources' dropdown menu")]
		public void ClickOnResourcesDropdownMenu() => _scientificPage.ClickToElement(ScientificPage.ScientificItems.ResourcesMenu);

		[Then(@"'Resources' list '(is|is not)' displayed")]
		public void CheckResourcesListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificPage.ScientificItems.ResourcesList);
			}),
				$"'Resources' list is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"Following options '(are|are not)' displayed in 'Resources' list")]
		public void CheckFollowingOptionsIsDisplayedInResourcesList(bool isDisplayed, Table table) => Assert.Multiple(() =>
		{
			foreach (var row in table.Rows)
			{
				Assert.AreEqual(isDisplayed, _scientificPage.GetListOfResourcesItems().Contains(row[0]),
						$"{row[0]} option is {(isDisplayed ? " not" : string.Empty)} displayed in 'Classroom' list!");
			}
		});


	}
}
