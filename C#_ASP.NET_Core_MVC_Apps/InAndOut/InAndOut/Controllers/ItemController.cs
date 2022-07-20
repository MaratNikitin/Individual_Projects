/*
 * This ASP.NET Core MVC app creates two pages used for tracking borrowed items and a list of expences allowing full range of CRUD
 *      operations using a created (Code First) SQL Server database. This app is inspired by a Udemy ASP.NET course.
 * Author: Marat Nikitin.
 * When: January 2022.
 * This is a controller for the Items page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objlist = _db.Items;
            return View(objlist);
        }

        // "GET" Create:
        public IActionResult Create()
        {
            return View();
        }

        // "POST" Create:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
