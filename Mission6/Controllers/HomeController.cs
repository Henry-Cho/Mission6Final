using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext task { get; set; }

        public HomeController(TaskContext someName)
        {
            task = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = task.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Form(TaskResponse ar)
        {
            if (ModelState.IsValid)
            {
                task.Add(ar);
                task.SaveChanges();
                return RedirectToAction("ViewTask");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewTask()
        {
            var taskList = task.Responses
                .Include(x => x.Category)
                .ToList();
            return View(taskList);
        }
    }
}
