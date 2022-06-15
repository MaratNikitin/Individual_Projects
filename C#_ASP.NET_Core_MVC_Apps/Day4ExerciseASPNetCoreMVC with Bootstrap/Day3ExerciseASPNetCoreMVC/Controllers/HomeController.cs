using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Day3ExerciseASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Day3ExerciseASPNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
      
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = 0;
            ViewBag.Total = 0;
            return View();
        }


        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountAmount = model.CalculateDiscountAmount();
                ViewBag.Total = model.CalculateTotal();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.Total = 0;
            }
            return View(model);
        }

    }
}
