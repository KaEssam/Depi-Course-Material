using Day1.Models;
using Microsoft.AspNetCore.Mvc;

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

            var tasks = _Context.taskItems.ToList();
            return View("Index",tasks);
        }

        public IActionResult Create()
        {
            var task = new TaskItem();
            return View(task);
        }

        
        public IActionResult Save(TaskItem task)
        {

            if(ModelState.IsValid == true)
            {
                _Context.taskItems.Add(task);
                _Context.SaveChanges();
                RedirectToAction("Index");
            }
    

            return View("Create",task);
        }
    }
}
