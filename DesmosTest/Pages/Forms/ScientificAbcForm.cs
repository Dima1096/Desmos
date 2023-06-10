

using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificAbcForm : Form
	{
		public ScientificAbcForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='+']"), "Main tab"){}
	}
}
