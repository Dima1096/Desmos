using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificMainForm : Form
	{
		public ScientificMainForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='s']"), "Abc tab") { }
	
	}
}
