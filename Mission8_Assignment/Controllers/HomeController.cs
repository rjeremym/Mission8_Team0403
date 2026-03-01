using Microsoft.AspNetCore.Mvc;
using Mission8_Assignment.Models;
using System.Linq;

namespace Mission8_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private IQuadrantRepository _repo;

        // Inject the repository through the constructor
        public HomeController(IQuadrantRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Show all tasks organized by quadrant
        public IActionResult Quadrants()
        {
            // Filter out completed tasks
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

            // Update this string if the form view has a different name
            return View("TaskForm", new Quadrant());
        }

        [HttpPost]
        public IActionResult AddTask(Quadrant q)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(q);
                return RedirectToAction("Quadrants");
            }

            // Reload dropdowns before returning the form
            ViewBag.Categories = _repo.Categories.ToList();
            return View("TaskForm", q);
        }

        // --- UPDATE ---
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _repo.Quadrants.Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories.ToList();

            // Reuse the same form for add and edit
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
            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Quadrant q)
        {
            _repo.DeleteTask(q);
            return RedirectToAction("Quadrants");
        }

        // --- MARK COMPLETE ---
        // Wire up a form/button in the view to POST to this action
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