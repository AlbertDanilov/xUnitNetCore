using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xUnitNetCore.Models;

namespace xUnitNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello world!";
            return View("Index");
        }
    }
}