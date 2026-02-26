using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission8_Assignment.Models;

namespace Mission8_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuadrantContext _context;

        public HomeController(QuadrantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var quadrants = _context.Quadrants
                .Include(q => q.Category)
                .ToList();
            return View(quadrants);
        }

        [HttpGet]
        public IActionResult addTask()
        {
            // Get categories from the database and create a SelectList
            // The SelectList takes the value field (CategoryId) and the text field (CategoryName)
            ViewBag.categories = new SelectList(
                _context.Categories
                        .OrderBy(c => c.CategoryName)
                        .ToList(),
                "CategoryId",       // value field
                "CategoryName"      // text field
            );

            // Pass a new quadrant object to the view
            return View("addTask", new Quadrant());
        }
    }
}
