using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_store.Models;
using Shopping_store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_store.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        StoreContext db;
        UserManager<User> _userManager;
        public ShoppingCartController(StoreContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Add(Guid carId,string url = null)
        {
            Car car = db.Cars.FirstOrDefault(c => c.Id == carId);

            if (car != null)
            {
                string userId = _userManager.GetUserId(User);
                User user = db.Users
                    .Include(u => u.Cars)
                    .Include(u => u.Counts).FirstOrDefault(u => u.Id == userId);

                if (user.Cars?.Contains(car) ?? false)
                {
                    CountCarsForUser count = user.Counts.FirstOrDefault(c => c.UserId == userId && c.CarId == car.Id);
                    count.CountOfCars++;
                }
                else
                {
                    CountCarsForUser count = new CountCarsForUser
                    {
                        UserId = userId,
                        CarId = car.Id
                    };
                    user.Cars.Add(car);
                    user.Counts.Add(count);
                }

                db.SaveChanges();
            }
            if (url != null)
                return RedirectToAction(url);
            return View(car);
        }

        [HttpGet]
        public IActionResult Description(Guid carId)
        {
            Car car = db.Cars.FirstOrDefault(c => c.Id == carId);

            if (car != null)
                return View(car);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ListOfCars()
        {
            string userId = _userManager.GetUserId(User);
            User user = db.Users
                .Include(u => u.Cars)
                .Include(u => u.Counts)
                .FirstOrDefault(u => u.Id == userId);

            return View(new CarsAndUserId
            {
                Cars = user.Cars,
                UserId = userId
            });
        }

        [HttpGet]
        public IActionResult Result()
        {
            string userId = _userManager.GetUserId(User);
            User user = db.Users
                .Include(u => u.Cars)
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == userId);

            Order order = new Order { Number = Guid.NewGuid().ToString() };

            user.Orders.Add(order);
            //user.Cars.RemoveAll(c => true);
            //db.SaveChanges();
            DeleteOnCondition(c => true, c => c.UserId == userId);
            return View(user.Orders.LastOrDefault().Number as object);
        }

        [HttpGet]
        public IActionResult Delete(Guid carId,bool all = false)
        {
            Car car = db.Cars.FirstOrDefault(c => c.Id == carId);

            if (car != null)
            {
                string userId = _userManager.GetUserId(User);
                User user = db.Users
                    .Include(u => u.Cars)
                    .Include(u => u.Counts)
                    .FirstOrDefault(u => u.Id == userId);

                if (!(user.Cars.Contains(car) && user.Counts
                    .FirstOrDefault(c => c.UserId == userId && c.CarId == car.Id).CountOfCars > 1) || all)
                {
                    DeleteOnCondition(c => c.Id == carId, c => c.UserId == userId && c.CarId == car.Id);
                }
                else
                {
                    user.Counts.FirstOrDefault(c => c.CarId == car.Id).CountOfCars--;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("ListOfCars");
        }

        [HttpGet]
        public IActionResult DeleteAll()
        {
            string userId = _userManager.GetUserId(User);
            DeleteOnCondition(c => true, c => c.UserId == userId);
            return RedirectToAction("ListOfCars");
        }

        void DeleteOnCondition(Predicate<Car> matchCar, Func<CountCarsForUser, bool> predicateCount)
        {
            string userId = _userManager.GetUserId(User);
            User user = db.Users
                .Include(u => u.Cars)
                .Include(u => u.Counts)
                .FirstOrDefault(u => u.Id == userId);

            user.Cars.RemoveAll(matchCar);
            db.Counts.RemoveRange(db.Counts.Where(predicateCount));
            db.SaveChanges();
        }
    }
}
