using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb.Models
{
	public class BlogEntry
	{
		[NotEmpty]
		public string Name { get; set; }
		
		[NotEmpty]
		public string Text { get; set; }
		
		public string FileName { get; set; }

	}
}
