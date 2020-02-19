using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmptyWeb.Models;

namespace EmptyWeb
{
	public class BlogEntriesStorage : IStorage
	{
		public IEnumerable<BlogEntry> BlogEntries { get; set; }

		public void Load()
		{

		}

		public void Save()
		{

		}
	}
}
