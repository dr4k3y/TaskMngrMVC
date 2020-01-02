using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagerMVC.Models
{
    public class TaskModel
    {
        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "You must specify task name")]
        public string TaskName { get; set; }
        [Display(Name = "Task Priority")]
        public DataLibrary.Models.Priority TaskPriority { get; set; }
        [Display(Name = "Task Status")]
        public DataLibrary.Models.Status TaskStatus { get; set; }
        [Display(Name = "Task Deadline")]
        [DataType(DataType.Date)]
        public DateTime TaskDeadline { get; set; }
        [Display(Name = "Task Details")]
        [DataType(DataType.MultilineText)]
        public string TaskDetails { get; set; }
    }
}