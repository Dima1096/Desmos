using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public abstract class BaseKeypadForm : Form
	{
		protected IButton KeypadItem(string keypadCommand) => ElementFactory.GetButton(By.XPath($"//span[@dcg-command='{keypadCommand}']"),
				   $"'{keypadCommand}' Keypad item");
		public BaseKeypadForm(By locator, string name) : base(locator, name){}

		public void HoverKeypadItem(string keypadCommand) => KeypadItem(keypadCommand).MouseActions.MoveToElement();

		public void ClickKeypadItem(string keypadCommand) => KeypadItem(keypadCommand).Click();

		public string GetAttributeKeypadItem(string attribute,string keypadCommand) => KeypadItem(keypadCommand).GetAttribute(attribute);
	}
}
