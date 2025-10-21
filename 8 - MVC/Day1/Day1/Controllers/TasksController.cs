using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day1.Controllers
{
    public class TasksController : Controller
    {

        private readonly AppDbContext _Context;

        public TasksController(AppDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = _Context.taskItems.Where(t => t.UserId ==userId).ToList();
            return View("Index",tasks);
        }

        //get
        // get form 
        // action for the pure html form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _Context.taskItems.Add(task);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }


        // action for the html  hELPER form
        public IActionResult CreateWithHelper()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWithHelper(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _Context.taskItems.Add(task);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }


        // action for the Tag Helper form
        public IActionResult CreateWithTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWithTag(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _Context.taskItems.Add(task);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _Context.taskItems.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _Context.taskItems.Remove(task);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var task = _Context.taskItems.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // get data for the task by id 
        public IActionResult Edit(int id)
        {
            var task = _Context.taskItems.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }


            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskItem model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var task = _Context.taskItems.FirstOrDefault(t => t.Id == id);

                if(task == null)
                {
                    return NotFound();
                }

                //update task

                task.Title = model.Title;

                _Context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(model);
        }
    }
}
