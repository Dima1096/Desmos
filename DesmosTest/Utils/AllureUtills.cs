using Aquality.Selenium.Browsers;
using DesmosTest.Models;
using System.Xml.Linq;

namespace DesmosTest.Utils
{
    public class AllureUtils
    {
        public static void AddEnvironment()
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", "yes"),
           new XElement("environment",
               new XElement("parameter",
                   new XElement("key", "Browser Name"),
                   new XElement("value", AqualityServices.Browser.BrowserName)),
                 new XElement("parameter",
                   new XElement("key", "Version"),
                   new XElement("value", AqualityServices.Browser.Driver.Capabilities["browserVersion"].ToString()))));
            xdoc.Save(@"allure-results\environment.xml");
        }
        public static void AddCategorys(){
          
            List<AllureCategoryModel> _data = new List<AllureCategoryModel>();
            _data.Add(new AllureCategoryModel()
            {
                Name = "Successful tests",
                MatchedStatuses = new List<string> { "passed"}
            });
            _data.Add(new AllureCategoryModel()
            {
                Name = "Product defects",
                MatchedStatuses = new List<string> { "failed" }
            });
            string json = System.Text.Json.JsonSerializer.Serialize(_data);
            File.WriteAllText(@"allure-results\categories.json", json);
        }
    }  
}

