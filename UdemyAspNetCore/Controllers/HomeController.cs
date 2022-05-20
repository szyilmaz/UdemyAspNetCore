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
            return View(new Customer());
        }

        public IActionResult CreateNew(Customer customer)
        {
            var id = 1;
            if (CustomerContext.Customers.Count > 0)
            {
                var lastCustomer = CustomerContext.Customers.Last();
                id = lastCustomer.Id + 1;
            }
            customer.Id = id;
            CustomerContext.Customers.Add(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var customerTobeRemoved =  CustomerContext.Customers.Find(c => c.Id == id);

            CustomerContext.Customers.Remove(customerTobeRemoved);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var customerTobeUpdated = CustomerContext.Customers.FirstOrDefault(c => c.Id == id);

            return View(customerTobeUpdated);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var customerTobeUpdated = CustomerContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            customerTobeUpdated.Age = customer.Age;
            customerTobeUpdated.FirstName = customer.FirstName;
            customerTobeUpdated.LastName = customer.LastName;

            return RedirectToAction("Index");
        }
    }
}
