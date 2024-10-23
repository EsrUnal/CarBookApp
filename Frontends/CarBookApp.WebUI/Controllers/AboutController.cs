﻿using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "About Us";
            ViewBag.v2 = "About Us";
            return View();
        }
    }
}
