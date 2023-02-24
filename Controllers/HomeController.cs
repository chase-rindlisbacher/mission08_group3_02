﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEditTask()
        {
            return View();
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
        public IActionResult Delete(int id)
        {
            var entry = TaskAppContext.Responses.Single(x => x.TaskId == id);
            return View(entry);
        }

        [HttpPost] // post delete
        public IActionResult Delete(TaskResponse entry)
        {
            TaskAppContext.Responses.Remove(entry);
            int v = TaskAppContext.SaveChanges();
            return RedirectToAction("Index"); // redirect with info to the movie list
        }
    }
}
