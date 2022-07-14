using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly ApplicationDBContext db;

        public ExpenseController(ApplicationDBContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objlist = db.Expenses;
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
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // "GET" Delete:
        public IActionResult Delete(int? ExpenseID)
        {
            if (ExpenseID == null || ExpenseID == 0)
            {
                return NotFound();
            }
            var obj = db.Expenses.Find(ExpenseID);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // "POST" Delete:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? ExpenseID)
        {
            var obj = db.Expenses.Find(ExpenseID);
            if(obj == null) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                db.Expenses.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // "GET" Update:
        public IActionResult Update(int? ExpenseID)
        {
            if (ExpenseID == null || ExpenseID == 0)
            {
                return NotFound();
            }
            var obj = db.Expenses.Find(ExpenseID);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // "POST" Update:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
