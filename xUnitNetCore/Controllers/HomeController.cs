using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xUnitNetCore.Models;

namespace xUnitNetCore.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController(IRepository r) 
        { 
            repository = r;
        }

        public IActionResult Index()
        {
            //ViewData["Message"] = "Hello world!";
            //return View("Index");

            return View(repository.GetAll());
        }
    }
}