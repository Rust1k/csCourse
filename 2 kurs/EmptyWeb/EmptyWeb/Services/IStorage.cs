using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
	public interface IStorage<T>
	{
		public void Load();
		public void Save();
	}
}
