using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using DataLibrary;
using static DataLibrary.Logic.TaskProcessor;

namespace TaskMenager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewTasks()
        {
            ViewBag.Massage = "Tasks list";
            var data = LoadTasks();
            List<TaskModel> tasks = new List<TaskModel>();
            foreach (var row in data)
            {
                tasks.Add(new TaskModel
                {
                    Id = row.Id,
                    TaskName = row.TaskName,
                    TaskPriority = row.TaskPriority,
                    TaskStatus = row.TaskStatus,
                    TaskDeadline = row.TaskDeadline,
                    TaskDetails = row.TaskDetails
                });
            }
            return View(tasks);
        }
        public ActionResult Tasks()
        {
            ViewBag.Message = "Your tasks.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tasks(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateTask(task.TaskName,
                    task.TaskPriority,
                    task.TaskStatus,
                    task.TaskDeadline,
                    task.TaskDetails);
                return RedirectToAction("ViewTasks");
            }

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int recordsAffected = DeleteTask(id);
            return RedirectToAction("ViewTasks");
        }
        public ActionResult Edit(int id, string TaskName, DataLibrary.Models.Priority TaskPriority, DataLibrary.Models.Status TaskStatus, DateTime TaskDeadline, string TaskDetails)
        {
            ViewBag.Message = "Edit your task";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                int recordsAffected = EditTask(
                    task.Id,
                    task.TaskName,
                    task.TaskPriority,
                    task.TaskStatus,
                    task.TaskDeadline,
                    task.TaskDetails);
                return RedirectToAction("ViewTasks");
            }

            return View();
        }
    }
}