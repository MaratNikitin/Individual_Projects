using Microsoft.AspNetCore.Mvc;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
 * see contact information, see available slips with the option of selecting them by dock
 * This controller is used to send a user to the Contact Page of the website
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace ASP_NET_Core_MVC_Lab1.Controllers
{
    public class ContactController : Controller
    {
        // Get: Contact/      
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
