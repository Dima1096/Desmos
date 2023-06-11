using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using DesmosTest.Pages.Forms;
using OpenQA.Selenium;

namespace DesmosTest.Pages
{
	public class ScientificPage : Form
	{
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
		}
	}
}
