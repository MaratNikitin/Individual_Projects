using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DbEntities_Class_Library;
using Microsoft.AspNetCore.Http;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This is the controller responsible for user authentification
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace ASP_NET_Core_MVC_Lab2.Controllers
{
    public class AccountController : Controller
    {
        // Route: /Account/Login
        public IActionResult Login(string returnUrl = "")
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer user) // from the Login form
        {
            Customer usr = UserManager.Authenticate(user.Username, user.Password);
            if (usr == null) // authentication failed
            {
                // saving a message about an authentication error for displaying to a user:
                TempData["Message"] = "Wrong Username-Password combination. Try again.";
                TempData["IsError"] = true;

                return View(); // stay on the login page
            }

            // get customer's id and store it in Session object
            HttpContext.Session.SetInt32("CurrentCustomer", (int)usr.ID);

            // get customer's first name and store it in Session object
            HttpContext.Session.SetString("CurrentCustomerFirstName", usr.FirstName.ToString());
                        

            // user != null -- authentication passed
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim("FirstName", usr.FirstName),
                new Claim("LastName", usr.LastName)
                //, new Claim(ClaimTypes.Role, usr.Role) // I guess roles are not required in this app
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // cookies authetication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Cookies", claimsPrincipal);

            if (String.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
                return RedirectToAction("Index", "Slips");
            else
                return Redirect(TempData["ReturnUrl"].ToString());
        }

        /// <summary>
        /// Logging out happens here
        /// </summary>
        /// <returns>A user is redirected to the /Slips page</returns>
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Slips");
        }

        /// <summary>
        /// It's a route for Error 403 - Access Denied
        /// </summary>
        /// <returns> A customized view for the access denied error </returns>
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer newCustomer)  
        {
            try
            {
                SlipDockLeaseSupplierManager.Add(newCustomer);
                TempData["Message"] = "Your registration was successful. Thank you, " + newCustomer.FirstName + "!";
                // it means that TempData["IsError"] will stay null by default
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
    }
}
