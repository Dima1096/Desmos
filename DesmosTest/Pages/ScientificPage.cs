using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using DesmosTest.Pages.Forms;
using OpenQA.Selenium;
using System.Text;

namespace DesmosTest.Pages
{
	public class ScientificPage : Form
	{
		private const string XpathToFindResultOfExpression = "//span[contains(@class,'dcg-mq-mathspeak')]/following-sibling::span";

		private const string XpathToFindExpressionValue = "//span[@class='dcg-mq-textarea']//following-sibling::span/*[self::var or self::span]";

		public ScientificMainForm MainForm => new ScientificMainForm();

		public ScientificAbcForm AbcForm => new ScientificAbcForm();

	    public ScientificFuncForm FuncForm => new ScientificFuncForm();

		private IButton MathToolsMenu => ElementFactory.GetButton(By.XPath("//div[contains(@class,'dcg-math-tools')]"),"Math Tools");

		private IButton ClassroomMenu => ElementFactory.GetButton(By.XPath("//div[contains(@class,'dcg-header-link')]//span[contains(text(),'Classroom')]"),
		   "Classroom");
		private IButton ResourcesMenu => ElementFactory.GetButton(By.XPath("//div[contains(@class,'dcg-header-link')]//span[contains(text(),'Resources')]"),
			"Resources");
		private ILabel MathToolsList => MathToolsMenu.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'dcg-header-link-dropdown')]"),
			"Math Tools List");
		private ILabel ClassroomList => ClassroomMenu.FindChildElement<ILabel>(By.XPath("/parent::div//div[contains(@class,'dcg-header-link-dropdown')]"),
		   "Classroom List");
		private ILabel ResourcesList => ResourcesMenu.FindChildElement<ILabel>(By.XPath("/parent::div//div[contains(@class,'dcg-header-link-dropdown')]"),
			"Resources List");

		private IList<ILabel> MathToolsItems => MathToolsMenu.FindChildElements<ILabel>(By.XPath("//li//span"));

		private ILabel DownloadOurAppMathToolItem => MathToolsMenu.FindChildElement<ILabel>(By.XPath("//li[contains(@class,'dcg-app-links')]/div"), "Download Our App Math Tool Item");

		private IList<ILabel> ClassroomItems => ClassroomMenu.FindChildElements<ILabel>(By.XPath("/parent::div//li/a"));

		private IList<ILabel> ResourcesItems => ResourcesMenu.FindChildElements<ILabel>(By.XPath("/parent::div//li/a"));

		private IButton MainTab => ElementFactory.GetButton(By.XPath("//div[@dcg-command='main']"), "Main Tab");

		private IButton AbcTab => ElementFactory.GetButton(By.XPath("//div[@dcg-command='ABC']"), "Abc Tab");

		private IButton FuncTab => ElementFactory.GetButton(By.XPath("//div[@dcg-command='functions']"),"Func Tab");

		public ILabel InputField => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'dcg-focused')]"), "InputField");

		private IButton ClearAllBtn => ElementFactory.GetButton(By.XPath("//div[@dcg-command='clearall']"), "Clear All button");
		
		private IList<ILabel> ExpressionFields => ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='dcg-basic-list']/div[@class='dcg-basic-expression']"));

		public ScientificPage() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]"), "Desmos Scientific Calculator"){}

		public bool IsElementDisplayed(ScientificItems item) => GetElements()[item].State.IsDisplayed;

		public void ClickToElement(ScientificItems item) => GetElements()[item].Click();

		public List<string> GetListOfMathToolsItems()
		{
			var list = MathToolsItems.Select(option => option.GetText()).ToList();
			list.Add(DownloadOurAppMathToolItem.GetText());
			return list;
		}

		public List<string> GetListOfClassroomItems() => ClassroomItems.Select(item => item.GetText()).ToList();

		public List<string> GetListOfResourcesItems() => ResourcesItems.Select(item => item.GetText()).ToList();

		public string GetAttribute(string attribute, ScientificItems item) => GetElements()[item].GetAttribute(attribute);

		public void HoverElement(ScientificItems item) => GetElements()[item].MouseActions.MoveToElement();

		public string GetLastExpressionValue() => GetExpressionValue(ExpressionFields.Last());

		public string GetResultOfLastExpression() => GetResultValue(ExpressionFields.Last());

		private string GetResultValue(IElement expressionField) => expressionField.FindChildElement<ILabel>(By.XPath(
			XpathToFindResultOfExpression)).GetText().Replace("=", "");

		public int GetCountOfExpressions() => ExpressionFields.Count;

		public string GetInputValue() => GetExpressionValue(InputField);

		private string GetExpressionValue(IElement expressionField)
		{
			var actualResult = new StringBuilder();
			foreach (var item in expressionField.FindChildElements<ILabel>(By.XPath(XpathToFindExpressionValue)))
			{
				actualResult.Append(item.GetText());
			}
			actualResult.ToString();
			return actualResult.ToString();
		}

		private IDictionary<ScientificItems, IElement> GetElements()
		{
			return new Dictionary<ScientificItems, IElement>
			{
				{ ScientificItems.MathToolsMenu, MathToolsMenu },
				{ ScientificItems.ClassroomMenu, ClassroomMenu },
				{ ScientificItems.ResourcesMenu, ResourcesMenu },
				{ ScientificItems.MathToolsList, MathToolsList },
				{ ScientificItems.ClassroomList, ClassroomList },
				{ ScientificItems.ResourcesList, ResourcesList },
				{ ScientificItems.MainTab, MainTab },
				{ ScientificItems.AbcTab, AbcTab },
				{ ScientificItems.FuncTab, FuncTab },
				{ ScientificItems.InputField, InputField },
				{ ScientificItems.ClearAllBtn, ClearAllBtn },
			};
		}
		public enum ScientificItems
		{
			MathToolsMenu,
			ClassroomMenu,
			ResourcesMenu,
			MathToolsList,
			ClassroomList,
			ResourcesList,
			MainTab,
			AbcTab,
			FuncTab,
			InputField,
			ClearAllBtn,
		}
	}
}
