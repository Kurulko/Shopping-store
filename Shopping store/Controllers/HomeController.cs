using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping_store.Models;
using Shopping_store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shopping_store.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        StoreContext db;
        public HomeController(StoreContext context)
        => db = context;

        public IActionResult Index()
            => View(db.Cars.ToList());

        [AllowAnonymous]
        public IActionResult Who()
        {
            bool isAdmin = User.IsInRole("Admin");
            bool isBuyer = User.IsInRole("Buyer");
            return Content($"Admin? {isAdmin} - Buyer? {isBuyer}");
        }
    }
}
