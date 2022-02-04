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
            var taskList = task.Responses
                .Where(x => x.Completed == false)
                .Include(x => x.Category)
                .ToList();
            return View(taskList);
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
                return RedirectToAction("Index");
            }
            ViewBag.Categories = task.Categories.ToList();
            return View();
        }

        // Edit a moive (GET)
        [HttpGet]
        public IActionResult Edit(int recordId)
        {
            // set this variable as false to indicate I am on Editing
            ViewBag.New = false;
            // get data from category model to display them on a cshtml
            ViewBag.Categories = task.Categories.ToList();

            // find a specific movie by its id
            var application = task.Responses.Single(x => x.TaskId == recordId);
            return View("Form", application);
        }

        // Edit a moive (POST)
        [HttpPost]
        public IActionResult Edit(TaskResponse ar)
        {
            // model validation
            if (ModelState.IsValid)
            {
                // edit a specific model
                task.Update(ar);
                task.SaveChanges();

                // show them in the index page
                return RedirectToAction("Index");
            }
            ViewBag.New = false;
            // if the model is not validated, get data from category model and show NewMoive cshtml
            ViewBag.Categories = task.Categories.ToList();
            return View("Form", ar);
        }

        // Delete
        public IActionResult Delete(int recordId)
        {
            // find a movie from DB by its id
            var record = task.Responses.Single(x => x.TaskId == recordId);
            task.Responses.Remove(record);
            task.SaveChanges();

            var taskList = task.Responses
                .Include(x => x.Category)
                .ToList();

            return RedirectToAction("Index", taskList);
        }

        public IActionResult MarkComplete(int recordId)
        {
            var record = task.Responses.Single(x => x.TaskId == recordId);

            record.Completed = true;
            task.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
