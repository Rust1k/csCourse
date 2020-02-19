using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmptyWeb
{
	public class HomeController
	{
		private IStorage storage;

		public HomeController(IStorage storage)
		{
			this.storage = storage;
		}

		public async Task GetForm(HttpContext context)
		{
			await context.Response.WriteAsync(File.ReadAllText("Views\\index.html"));
		}

		public async Task AddEntry(HttpContext context)
		{
			string filePath = "Files";

			int fileCount = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories).Length;
			fileCount++;

			foreach (var formFile in context.Request.Form.Files)
			{
				if (formFile.Length > 0)
				{
					string newFile = Path.Combine(filePath, fileCount + System.IO.Path.GetExtension(formFile.FileName));
					using (var inputStream = new FileStream(newFile, FileMode.Create))
					{
						// read file to stream
						await formFile.CopyToAsync(inputStream);
						// stream to byte array
						byte[] array = new byte[inputStream.Length];
						inputStream.Seek(0, SeekOrigin.Begin);
						inputStream.Read(array, 0, array.Length);
						// get file name
						string fName = formFile.FileName;
					}
				}
			}

			string name = context.Request.Form["name"];
			string text = context.Request.Form["text"];
			string txtFileName = Path.Combine(filePath, fileCount + ".txt");
			File.AppendAllLines(txtFileName, new string[] {name, text});
			
			await context.Response.WriteAsync("New Entry was added");
		}

		public async Task GetPosts(HttpContext context)
		{
			string filePath = "Files";

			string[] files = Directory.GetFiles(filePath, "*.txt", SearchOption.AllDirectories);

			foreach (var file in files)
			{
				
			}

			await context.Response.WriteAsync("!");
		}
	}
}
