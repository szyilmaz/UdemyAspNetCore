using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore.Models;

namespace UdemyAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Customer customer = new () { FirstName = "Zafer", LastName = "YILMAZ", Age = 39 };
            return View(customer);
        }
    }
}
