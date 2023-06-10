using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificFuncForm : Form
	{
		public ScientificFuncForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='round']"), "Main tab") { }
		
		
	}
}
