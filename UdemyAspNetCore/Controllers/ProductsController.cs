﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
