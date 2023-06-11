using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificMainForm : BaseKeypadForm
	{
		public ScientificMainForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='+']"), "Main Form") { }
	}
}
