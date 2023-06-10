using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DesmosSpecFlow.Transformations
{
	[Binding]
	public class TypeTransformations
	{
		private readonly ScenarioContext _scenarioContext;

		public TypeTransformations(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[StepArgumentTransformation]
		public bool TransformationTextToBool(string text) 
		{
			return text switch
			{
				"is" => true,
				"are" => true,
				"is not" => false,
				"are not" => false,
				_ => throw new Exception($"Transformation text <{text}> to bool is not implemented.")
			};

		}
	}
}
