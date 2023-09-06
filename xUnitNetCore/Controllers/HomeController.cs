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

        public IActionResult GetUser(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            User user = repository.Get(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult AddUser() => View();

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}