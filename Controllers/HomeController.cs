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

        
        /*Home page default view where your tasks to do will be listed out*/
        public IActionResult Index()
        {
            var tasks = _taskContext.Responses
                .Include(x => x.Category)
                .ToList();
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View(tasks);
        }

        /*Get method to render page to add tasks to do*/
        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.Category = _taskContext.Categories.ToList();
            return View();
        }
        /*Post method to submit the tasks and update the database*/
        [HttpPost]
        public IActionResult AddEditTask(TaskResponse taskyboi)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(taskyboi);
                _taskContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                BadRequest(ModelState);
                return View(taskyboi);
            }
         
        }

        /*Get method to edit a single task from the database*/
        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            ViewBag.Categories = _taskContext.Categories.ToList();

            var task = _taskContext.Responses.Single(x => x.TaskId == TaskID);
            return View("AddEditTask", task);
        }

        /*Post method to update the single task from the database*/
        [HttpPost]
        public IActionResult Edit(TaskResponse ar)
        {
            _taskContext.Update(ar);
            _taskContext.SaveChanges();
            return RedirectToAction("Index");
        }

        /**/
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
