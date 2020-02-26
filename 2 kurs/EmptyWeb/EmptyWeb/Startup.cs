using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmptyWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmptyWeb
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IMessageSender, EmailMessageSender>();
			services.AddTransient<IStorage<BlogEntry>, ItemsStorage<BlogEntry>>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStorage<BlogEntry> storage)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", new HomeController(storage).GetForm);
				endpoints.MapGet("/Home/Entry/{EntryName}", new HomeController(storage).EditEntry);
				endpoints.MapPost("/Home/AddEntry", new HomeController(storage).AddEntry);
			});
			
		}
	}
}
