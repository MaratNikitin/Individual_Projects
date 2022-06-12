using System.Diagnostics;
using ASP_NET_Core_MVC_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
 * see contact information, see available slips with the option of selecting them by dock
 * This is a default controller which is used to send a user to the Home Page of the website
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */ 

namespace ASP_NET_Core_MVC_Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Get: localhost
        public IActionResult Index()
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
