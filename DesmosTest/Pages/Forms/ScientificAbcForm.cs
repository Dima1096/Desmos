using OpenQA.Selenium;

namespace DesmosTest.Pages.Forms
{
	public class ScientificAbcForm : BaseKeypadForm
	{
		public ScientificAbcForm() : base(By.XPath("//div[contains(@class,'dcg-scientific-container')]//span[@dcg-command='s']"), "ABC tab"){}
	}
}
