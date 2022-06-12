using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using ASP_NET_Core_MVC_Lab1.Models;
using DbEntities_Class_Library;
using Microsoft.AspNetCore.Mvc;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This controller is used to help generate and redirect a user to pages related to displaying information about slips
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace ASP_NET_Core_MVC_Lab1.Controllers
{  
    public class SlipsController : Controller
    {
        // Get: Slips/
        public IActionResult Index()
        {
            // creating lists containing all data from the Slips, Dock & Lease tables of the DB:
            List<Slip> slipList = SlipDockLeaseSupplierManager.GetSlips();
            List<Dock> dockList = SlipDockLeaseSupplierManager.GetDocks();
            List<Lease> leaseList = SlipDockLeaseSupplierManager.GetLeases();

            // creating a combinedList by joining Dock and Slip tables - it includes all slips (both occupied and vacant)
            List<SlipDockLeaseViewModel> combinedList =
                (
                    from s in slipList
                        join d in dockList on  s.DockID equals d.ID 
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

        [HttpGet] //Get: Slips/Search
        public IActionResult Search()
        {
            var docksList = SlipDockLeaseSupplierManager.GetDocksAsKeyValuePairs(); // list of all lists is generated
            SelectList list = new SelectList(docksList, "Value", "Text"); // only he primary key and dock names are retrieved
            ViewBag.DockNames = list; // dock names are saved to be displayed as options of a dropdown list
            return View();
        }


        // GET: Slips/SearchSlip/2
        public IActionResult SearchSlip(int id) // display slips by the selected dock
        {
            Dock dockChosen = SlipDockLeaseSupplierManager.FindDock(id); // Dock instance with a certain ID is found
            ViewBag.DockChosen = dockChosen.ID; // found Dock object is saved in the ViewBag                     
            List<Slip> slipList = SlipDockLeaseSupplierManager.GetSlipsByDockID(id); // creating a list of slips belonging to the chosen dock
            List<Lease> leaseList = SlipDockLeaseSupplierManager.GetLeasesByDockID(id); // creating a list of leases belonging to the chosen dock

            // creating a combinedList by joining Dock and Slip tables - it includes all slips (both occupied
              // and vacant belonging to the chosen dock)
            List<SlipDockLeaseViewModel> combinedList =
                (
                    from s in slipList
                    where s.DockID == dockChosen.ID // selecting only data belonging to the selected dock
                    orderby s.ID
                    select new SlipDockLeaseViewModel
                    {
                        SlipID = s.ID,
                        Width = s.Width,
                        Length = s.Length,
                        DockName = dockChosen.Name,
                        WaterService = dockChosen.WaterService,
                        ElectricalService = dockChosen.ElectricalService
                    }
                ).ToList();

            // creating a list of occupied slips list by joining three tables, only for belonging to the chosen dock
              // - these slips should not be displayed to a user by default
            List<SlipDockLeaseViewModel> combinedOccupiedList =
                (
                    from s in slipList
                    join l in leaseList on s.ID equals l.SlipID
                    where s.DockID == dockChosen.ID // selecting only data belonging to the selected dock
                    orderby s.ID
                    select new SlipDockLeaseViewModel
                    {
                        SlipID = s.ID,
                        Width = s.Width,
                        Length = s.Length,
                        DockName = dockChosen.Name,
                        WaterService = dockChosen.WaterService,
                        ElectricalService = dockChosen.ElectricalService
                    }
                ).ToList();

            // removing from the full list those slips that are occupied/booked:
            combinedList.RemoveAll(r => combinedOccupiedList.Any(a => a.SlipID == r.SlipID));

            return View("SearchSlip", combinedList); // only available slips of the chosen dock are returned for display
        }
    }
}
