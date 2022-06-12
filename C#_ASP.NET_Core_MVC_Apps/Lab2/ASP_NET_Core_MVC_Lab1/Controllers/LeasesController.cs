using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ASP_NET_Core_MVC_Lab1.Models;
using DbEntities_Class_Library;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This is the controller responsible for allowing leasing slips and seeing own leased slips
    to authenticated users
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace ASP_NET_Core_MVC_Lab2.Controllers
{
    [Authorize] // Every page that is served by this conntroller, is available only to authenticated users
    public class LeasesController : Controller
    {
        public IActionResult Index()
        {
            // creating lists containing all data from the Slips, Dock & Lease tables of the DB:
            List<Slip> slipList = SlipDockLeaseSupplierManager.GetSlips();
            List<Dock> dockList = SlipDockLeaseSupplierManager.GetDocks();
            List<Lease> leaseList = SlipDockLeaseSupplierManager.GetLeases();

            // creating a combinedList by joining Dock and Slip tables - it includes all slips
            //    (both occupied and vacant)
            List<SlipDockLeaseViewModel> combinedList =
                (
                    from s in slipList
                    join d in dockList on s.DockID equals d.ID
                    orderby s.ID
                    select new SlipDockLeaseViewModel
                    {
                        SlipID = s.ID,
                        Width = s.Width,
                        Length = s.Length,
                        DockName = d.Name,
                        WaterService = d.WaterService,
                        ElectricalService = d.ElectricalService
                    }
                ).ToList();

            // creating a list of occupied slips list by joining three tables
            // - this slips list should not be displayed to a user by default
            List<SlipDockLeaseViewModel> combinedOccupiedList =
                (
                    from s in slipList
                    join d in dockList on s.DockID equals d.ID
                    join l in leaseList on s.ID equals l.SlipID
                    orderby s.ID
                    select new SlipDockLeaseViewModel
                    {
                        SlipID = s.ID,
                        Width = s.Width,
                        Length = s.Length,
                        DockName = d.Name,
                        WaterService = d.WaterService,
                        ElectricalService = d.ElectricalService
                    }
                ).ToList();

            // removing from the full list those slips that are occupied/booked:
            combinedList.RemoveAll(r => combinedOccupiedList.Any(a => a.SlipID == r.SlipID));

            return View(combinedList); // only available slips are returned for display
        }


        // GET: Leases/Lease/2
        public IActionResult Lease(int id) // lease a slip with this chosen id
        {
            ViewBag.SelectedSlipID = id; // saving the selected SlipID in the viewbag for later use in the view
            ViewBag.CurrentCustomer = HttpContext.Session.GetInt32("CurrentCustomer"); // saving the selected ...
                                                            // ... SlipID in the viewbag for later use in the view
            return View(new Lease()); // LeaseId is initialized to zero           
        }

        // POST: Leases/Lease/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Lease(Lease newLease) // lease a slip with this chosen id
        {
            try
            {
                SlipDockLeaseSupplierManager.Add(newLease);
                TempData["Message"] = $"Slip with ID = {newLease.SlipID} was successully leased to you!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //Get: Slips/MySlips
        public IActionResult MySlips()
        {
            List<LeaseSlipViewModel> customerSlips = null;
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer"); //current registered customer's ID
                                                                               //is retrieved from session
            // list of slips leased by the current authenticated customer is generated:
            customerSlips = SlipDockLeaseSupplierManager.GetPropertiesByCustomer((int)customerID);
            return View(customerSlips);
        }
    }
}
