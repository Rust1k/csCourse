using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SNNetCoreMVC.Models;

namespace SNNetCoreMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;


		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}


		[ServiceFilter(typeof(LoggingActionFilter))]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Calculate()
		{
			ICalculator calc = new CalculatorFactory(_logger).CreateCalculator();

			return View(calc.Add(1, 2));
		}

		public IActionResult Calc()
		{
			Calc calc = new Calc();

			return View(calc.Multiply(1, 20));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
