using System;
using Microsoft.AspNetCore.Mvc;

namespace ComingSoon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
