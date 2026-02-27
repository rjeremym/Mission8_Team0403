using Microsoft.AspNetCore.Mvc;
using Mission8_Assignment.Models;
using System.Linq;

namespace Mission8_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private IQuadrantRepository _repo;

        // Constructor asks for the Repository, NOT the Context directly!
        public HomeController(IQuadrantRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        // --- READ: The Main Quadrants View ---
        public IActionResult Quadrants()
        {
            // The rubric says: "Only display tasks that have not been completed."
            var tasks = _repo.Quadrants
                .Where(x => x.completed == false)
                .ToList();

            return View(tasks);
        }

        // --- CREATE ---
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            
            // I am assuming Teammate #2 names the form view "TaskForm.cshtml". 
            // If they name it "AddEdit.cshtml", change this string!
            return View("TaskForm", new Quadrant()); 
        }

        [HttpPost]
        public IActionResult AddTask(Quadrant q)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(q);
                return RedirectToAction("Quadrants"); // Send them back to the grid
            }
            
            // If invalid, reload dropdowns and show form again
            ViewBag.Categories = _repo.Categories.ToList();
            return View("TaskForm", q);
        }

        // --- UPDATE ---
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _repo.Quadrants.Single(x => x.TaskId == id);
            
            ViewBag.Categories = _repo.Categories.ToList();
            
            // We reuse the same form view for editing
            return View("TaskForm", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Quadrant q)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(q);
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = _repo.Categories.ToList();
            return View("TaskForm", q);
        }

        // --- DELETE ---
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.Quadrants.Single(x => x.TaskId == id);
            return View(taskToDelete); // Assuming Teammate #3 makes Delete.cshtml
        }

        [HttpPost]
        public IActionResult Delete(Quadrant q)
        {
            _repo.DeleteTask(q);
            return RedirectToAction("Quadrants");
        }

        // --- MARK COMPLETE (Extra feature to make life easy) ---
        // Teammate #3 can just put a form with a button next to each task to hit this action
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.Quadrants.Single(x => x.TaskId == id);
            task.completed = true;
            _repo.UpdateTask(task);
            
            return RedirectToAction("Quadrants");
        }
    }
}