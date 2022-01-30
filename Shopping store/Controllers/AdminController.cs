using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_store.Models;
using System;
using System.Linq;

namespace Shopping_store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        StoreContext db;
        public AdminController(StoreContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid && !db.Cars.Contains(car))
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return ToHomeIndex();
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult Delete(Guid? carId)
        {
            if (carId != null)
            {
                Car car = db.Cars.FirstOrDefault(c => c.Id == carId);
                if (car != null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();
                }
            }
            return ToHomeIndex();
        }

        [HttpGet]
        public IActionResult Update(Guid? carId)
        {
            if (carId != null)
            {
                Car car = db.Cars.FirstOrDefault(c => c.Id == carId);
                if (car != null)
                    return View(car);
            }
            return ToHomeIndex();
        }
        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Update(car);
                db.SaveChanges();
                return ToHomeIndex();
            }
            return View(car);
        }

        IActionResult ToHomeIndex()
            => RedirectToAction("Index", "Home");
    }
}
