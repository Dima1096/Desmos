using AngleSharp.Dom;
using Aquality.Selenium.Browsers;
using DesmosTest.Configurations;
using DesmosTest.Pages;
using ICSharpCode.SharpZipLib;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static DesmosTest.Pages.ScientificPage;

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
		public void CheckMathToolsDropdownMenuIsDisplayed(bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(ScientificItems.MathToolsMenu), 
			$"'MathToolsMenu' is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[When(@"I click on the 'Math tools' dropdown menu")]
		public void ClickOnMathToolsDropdownMenu() => _scientificPage.ClickToElement(ScientificItems.MathToolsMenu);

		[Then(@"'Math tools' list '(is|is not)' displayed")]
		public void CheckMathToolsListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificItems.MathToolsList);
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
		public void CheckClassroomDropdownMenuIsDisplayed(bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(ScientificItems.ClassroomMenu),
		   $"'Classroom' is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[When(@"I click on the 'Classroom' dropdown menu")]
		public void ClickOnClassroomDropdownMenu() => _scientificPage.ClickToElement(ScientificItems.ClassroomMenu);

		[Then(@"'Classroom' list '(is|is not)' displayed")]
		public void CheckClassroomListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificItems.ClassroomList);
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
		public void ClickOnResourcesDropdownMenu() => _scientificPage.ClickToElement(ScientificItems.ResourcesMenu);

		[Then(@"'Resources' list '(is|is not)' displayed")]
		public void CheckResourcesListIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.IsElementDisplayed(ScientificItems.ResourcesList);
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

		[Then(@"'([^']*)' tab '(is|is not)' displayed")]
		public void CheckMainTabIsDisplayed(string tabName, bool isDisplayed) => Assert.IsTrue(_scientificPage.IsElementDisplayed(GetTabItem(tabName)),
		   $"'{tabName}' tab is{(isDisplayed ? " not" : string.Empty)} displayed!");

		[Then(@"'([^']*)' tab '(is|is not)' selected")]
		public void CheckTabIsSelected(string tabName, bool isSelected)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isSelected == bool.Parse(_scientificPage.GetAttribute("aria-pressed", GetTabItem(tabName)));
			}),
				$"'{tabName}' tab is{(isSelected ? " not" : string.Empty)} selected!");
		}

		[When(@"I click on '([^']*)' tab")]
		public void ClickOnTab(string tabName) => _scientificPage.ClickToElement(GetTabItem(tabName));

		[When(@"I hover '([^']*)' tab")]
		public void HoverTab(string tabName) => _scientificPage.HoverElement(GetTabItem(tabName));

		[Then(@"'([^']*)' tab '(is|is not)' highlighted")]
		public void CheckTabIsHighlighted(string tabName, bool isHighlighted)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isHighlighted == _scientificPage.GetAttribute("class", GetTabItem(tabName)).Contains("dcg-hovered");
			}),
				$"'{tabName}' tab is{(isHighlighted ? " not" : string.Empty)} highlighted!");
		}

		private ScientificItems GetTabItem(string tabName) 
		{
			switch (tabName.ToLower())
			{
				case "main":
					return ScientificItems.MainTab;
				case "abc":
					return ScientificItems.AbcTab;
				case "func":
					return ScientificItems.FuncTab;
				default:
					throw new NotImplementedException($"{tabName} tab is not implemented");
			}
		}

		[Then(@"'Main' keypad '(is|is not)' displayed")]
		public void CheckMainKeypadIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.MainForm.State.IsDisplayed;
			}),
				$"'Main' keypad is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"'Abc' keypad '(is|is not)' displayed")]
		public void CheckAbcKeypadIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.AbcForm.State.IsDisplayed;
			}),
				$"'Abc' keypad is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}

		[Then(@"'Func' keypad '(is|is not)' displayed")]
		public void CheckFuncKeypadIsDisplayed(bool isDisplayed)
		{
			Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() =>
			{
				return isDisplayed == _scientificPage.FuncForm.State.IsDisplayed;
			}),
				$"'Func' keypad is{(isDisplayed ? " not" : string.Empty)} displayed!");
		}


	}
}
