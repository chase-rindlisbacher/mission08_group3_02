using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEditTask()
        {
            return View();
        }
     
    }
}
