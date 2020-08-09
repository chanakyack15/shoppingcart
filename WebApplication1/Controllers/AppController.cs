using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AppController : Controller
    {
        private readonly IRepo reposi;

        //private readonly Repo _context;

        public AppController(IRepo reposi)
        {
           
            this.reposi = reposi;
        }
        public IActionResult Index()
        {
            //var results = _context.Products.ToList();
            return View();
        }
        public IActionResult Cart() {

            /*
             var results = from p in _context.Products
                           orderby p.Title 
                           select p;
             return View(results.ToList());*/
             
            var results = reposi.GetAllProducts();
            return View(results);
        }
        public IActionResult Login() {
            ViewBag.Title = "Login";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                // PUT IT IN DATABASE
            }
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        
    }
}
