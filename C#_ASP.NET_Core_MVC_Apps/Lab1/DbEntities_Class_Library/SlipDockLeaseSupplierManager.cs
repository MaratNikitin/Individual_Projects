using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
 * see contact information, see available slips with the option of selecting them by dock
 * This file is a repository of methods for working with data of the InlandMarina database
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

    }
}
