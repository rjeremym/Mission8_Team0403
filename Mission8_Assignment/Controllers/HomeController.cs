using Microsoft.AspNetCore.Mvc;
using Mission8_Assignment.Models;
using System.Diagnostics;

namespace Mission8_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
