using System;
using System.Collections.Generic;
using System.Security;
using BROK5719.Model.Models;
using DotLiquid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BROK5719.Model
{
	public class MainDotLiquid
	{
		public string RenderStep1(DotLiquidModel dotLiquidModel)
		{
			Template template = Template.Parse(dotLiquidModel.Temaplate);
			
			var render = template.Render(Hash.FromAnonymousObject(new {article = dotLiquidModel.Text}));
			return render;
		}

		public string RenderStep2(string templatetest, string templateName, string text)
		{
			templateName = templateName + ".";
			templatetest = templatetest.Replace(templateName, "");

			var json = JsonConvert.DeserializeObject<IDictionary<string, object>>(text);
			var jsonHash = Hash.FromDictionary(json);

			var template = Template.Parse(templatetest);
			var render = template.Render(jsonHash);

			return render;
		}
	}
}
