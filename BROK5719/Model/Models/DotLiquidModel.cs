using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace BROK5719.Model.Models
{
	public class DotLiquidModel
	{
		public string Temaplate { get; set; }

		public string TemplateName { get; set; }

		public DotLiquidTextModel Text { get; set; }

	}

	public class DotLiquidTextModel : Drop
	{
		public string created_at { get; set; }

		public string rubric { get; set; }

		public string title { get; set; }

		public string @abstract { get; set; }

		public string url { get; set; }

		public string image_url { get; set; }
	}
}
