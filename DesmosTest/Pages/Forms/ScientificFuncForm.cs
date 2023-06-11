using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificFuncForm : BaseKeypadForm
	{
		public ScientificFuncForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='round']"), "Func tab") { }
	}
}
