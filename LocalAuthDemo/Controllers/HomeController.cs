using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalAuthDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace LocalAuthDemo.Controllers
{
    [Route("Home")]
    [Route("")]
    public class HomeController : Controller
    {
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
