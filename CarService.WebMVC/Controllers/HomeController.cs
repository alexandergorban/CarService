using System.Diagnostics;
using CarService.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ClearForm()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult SendOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}
