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
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateWithForm()
        {
            var firstName = HttpContext.Request.Form["firstName"].ToString();
            var lastName = HttpContext.Request.Form["lastName"].ToString();
            var age = int.Parse(HttpContext.Request.Form["age"].ToString());

            var id = 0;

            if (CustomerContext.Customers.Count > 0)
            {
                var lastCustomer = CustomerContext.Customers.Last();
                id = lastCustomer.Id + 1;
            }
           

            CustomerContext.Customers.Add(new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var id = int.Parse(RouteData.Values["id"].ToString());
            var customerTobeRemoved =  CustomerContext.Customers.Find(c => c.Id == id);

            CustomerContext.Customers.Remove(customerTobeRemoved);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            var id = int.Parse(RouteData.Values["id"].ToString());
            var customerTobeUpdated = CustomerContext.Customers.FirstOrDefault(c => c.Id == id);

            return View(customerTobeUpdated);
        }

        [HttpPost]
        public IActionResult UpdateCustomer()
        {
            var id = int.Parse(HttpContext.Request.Form["id"].ToString());
            var firstName = HttpContext.Request.Form["firstName"].ToString();
            var lastName = HttpContext.Request.Form["lastName"].ToString();
            var age = int.Parse(HttpContext.Request.Form["age"].ToString());

            var customerTobeUpdated = CustomerContext.Customers.FirstOrDefault(c => c.Id == id);
            customerTobeUpdated.Age = age;
            customerTobeUpdated.FirstName = firstName;
            customerTobeUpdated.LastName = lastName;

            return RedirectToAction("Index");
        }
    }
}
