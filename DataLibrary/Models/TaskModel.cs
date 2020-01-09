using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public enum Priority
    {
        Low,
        Normal,
        High
    }
    public enum Status
    {
        New,
        InProgress,
        Done
    }
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Priority TaskPriority { get; set; }
        public Status TaskStatus { get; set; }
        public DateTime TaskDeadline { get; set; }
        public string TaskDetails { get; set; }
        public int UserId { get; set; }
    }
}
