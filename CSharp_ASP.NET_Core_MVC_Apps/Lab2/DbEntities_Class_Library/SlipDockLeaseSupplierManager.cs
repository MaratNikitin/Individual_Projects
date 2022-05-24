using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file is a repository of methods for working with all data of the InlandMarina database, including the 
    Customers table despite it's not mentioned in the name of this file. 
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
    public static class SlipDockLeaseSupplierManager
    {
        /// <summary>
        /// Retrieves all slips data
        /// </summary>
        /// <returns>List of slips</returns>
        public static List<Slip> GetSlips()
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Slips.ToList();
        }


        /// <summary>
        /// Retrieves all docks data
        /// </summary>
        /// <returns>List of docks</returns>
        public static List<Dock> GetDocks()
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Docks.ToList();
        }


        /// <summary>
        /// Retrieves all leases data
        /// </summary>
        /// <returns>List of leases</returns>
        public static List<Lease> GetLeases()
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Leases.ToList();
        }

        /// <summary>
        /// Retrieves all customers data
        /// </summary>
        /// <returns>List of customers</returns>
        public static List<Customer> GetCustomers()
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Customers.ToList();
        }


        /// <summary>
        /// Retrieves list of only Dock IDs and Names
        /// </summary>
        /// <returns>List of anonymous type </returns>
        public static IList GetDocksAsKeyValuePairs()
        {
            InlandMarinaContext db = new InlandMarinaContext();
            var types = db.Docks.OrderBy(d => d.Name).
                Select(d => new { Value = d.ID, Text = d.Name }).ToList();
            return types;
        }


        /// <summary>
        /// Find docks with given id
        /// </summary>
        /// <param name="id"> Dock id</param>
        /// <returns>Dock with this id or null if not found</returns>
        public static Dock FindDock(int id)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            Dock chosenDock = db.Docks.Find(id);
            return chosenDock;
        }

        /// <summary>
        /// get slips of chosen dock (by the dock's ID)
        /// </summary>
        /// <param name="dockID"> ID of the dock</param>
        /// <returns>List of slips</returns>
        public static List<Slip> GetSlipsByDockID(int id)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Slips.Where(m => m.DockID == id).ToList();
        }


        /// <summary>
        /// Get leases of chosen dock by the dock's ID
        /// </summary>
        /// <param name="dockID"> ID of the dock</param>
        /// <returns>list of slips</returns>
        public static List<Lease> GetLeasesByDockID(int id)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            return db.Leases.Where(m => m.ID == id).ToList();
        }

        /// <summary>
        /// Adds a new lease
        /// </summary>
        /// <param name="newLease">New lease to add</param>
        public static void Add(Lease newLease)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            newLease.ID = 0; // it is needed to get around that problem of inserting no LeaseID
            db.Leases.Add(newLease);
            db.SaveChanges();
        }

        public static List<LeaseSlipViewModel> GetPropertiesByCustomer(int id)
        {
            
            InlandMarinaContext db = new InlandMarinaContext();
            List<Slip> slipList = SlipDockLeaseSupplierManager.GetSlips();
            List<Dock> dockList = SlipDockLeaseSupplierManager.GetDocks();
            List<Lease> leaseList = SlipDockLeaseSupplierManager.GetLeases();
            List<Customer> customerList = SlipDockLeaseSupplierManager.GetCustomers();
            List<LeaseSlipViewModel> customerSlips =
                (
                    from s in slipList
                    join d in dockList on s.DockID equals d.ID
                    join l in leaseList on s.ID equals l.SlipID
                    join c in customerList on l.CustomerID equals c.ID
                    where c.ID == id // choosing only by the selected customer
                    orderby l.ID
                    select new LeaseSlipViewModel
                    {
                        LeaseID = l.ID,
                        SlipID = s.ID,
                        Width = s.Width,
                        Length = s.Length,
                        DockName = d.Name,
                        WaterService = d.WaterService,
                        ElectricalService = d.ElectricalService,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Phone = c.Phone,
                        City = c.City
                    }
                ).ToList();
            return customerSlips;
        }


        /// <summary>
        /// Adds a new customer to DB
        /// </summary>
        /// <param name="newCustomer">New customer to add</param>
        public static void Add(Customer newCustomer)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            newCustomer.ID = 0; // it is needed to get around that problem of
                                // inserting no CustomerID for aut0 creating CustomerID
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

    }
}
