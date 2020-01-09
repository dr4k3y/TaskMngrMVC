using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;
using DataLibrary;
using static DataLibrary.Logic.TaskProcessor;
using static DataLibrary.Logic.UserProcessor;

namespace TaskManagerMVC.Controllers
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
            int id;
            if (Session["UserID"]==null)
            {
                id = 0;
            }
            else
            {
                id = Convert.ToInt32(Session["UserID"]);
            }
            var data = LoadTasks(id);
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
                    task.TaskDetails,
                    Convert.ToInt32(Session["UserID"]));
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
        public ActionResult Register()
        {
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                int recordsAffected = CreateUser(
                    user.Username,
                    user.Password
                    );
                return RedirectToAction("ViewTasks");
            }
            return View();
        }
        public ActionResult Test()
        {
            CreateUser("adam", "adsfsdafsdaf");
            return RedirectToAction("ViewTasks");
        }
        public ActionResult LogIn()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserModel user)
        {
            int userID=AuthenticateUser(user.Username, user.Password);
            Session["UserID"]=userID.ToString();
            Session["UserName"] = user.Username.ToString();
            return PartialView();
        }
        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }
    }
}