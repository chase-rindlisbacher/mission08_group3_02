using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission08_group3_02.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_02.Controllers
{
    public class HomeController : Controller
    {
        

        private TaskAppContext _taskContext { get; set; }

        public HomeController(TaskAppContext taskContext)
        {
            _taskContext = taskContext;
        }

        

        public IActionResult Index()
        {
            var tasks = _taskContext.Responses
                .Include(x => x.Category)
                .ToList();
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.Category = _taskContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddEditTask(TaskResponse taskyboi)
        {

            _taskContext.Add(taskyboi);
            _taskContext.SaveChanges();
            return RedirectToAction("Index");
         
        }

        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            ViewBag.Categories = _taskContext.Categories.ToList();

            var task = _taskContext.Responses.Single(x => x.TaskId == TaskID);
            return View("AddEditTask", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse ar)
        {
            _taskContext.Update(ar);
            _taskContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // DELETE
        [HttpGet] // get delete
        public IActionResult Delete(int TaskID)
        {
            var entry = _taskContext.Responses.Single(x => x.TaskId == TaskID);
            return View(entry);
        }

        [HttpPost] // post delete
        public IActionResult Delete(TaskResponse entry)
        {
            _taskContext.Responses.Remove(entry);
            int v = _taskContext.SaveChanges();
            return RedirectToAction("Index"); // redirect with info to the movie list
        }
    }
}
