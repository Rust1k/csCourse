using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmptyWeb.Models;

namespace EmptyWeb
{
	public class ItemsStorage<T> : IStorage<T>
	{
		public List<T> Items { get; set; }

		public void Load()
		{
			// загрузка всех записей блога из директории
		}

		public void Save()
		{
			// сохранение вновь добавленных записей
		}
	}
}
