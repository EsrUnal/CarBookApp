﻿using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
