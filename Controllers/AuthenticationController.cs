﻿using Microsoft.AspNetCore.Mvc;

namespace webdersi.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}