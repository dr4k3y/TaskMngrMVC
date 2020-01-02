using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class TaskProcessor
    {
        public static int CreateTask(string taskName, Priority taskPriority, Status taskStatus, DateTime taskDeadline, string taskDetails)
        {
            DataLibrary.Models.TaskModel data = new Models.TaskModel
            {
                TaskName = taskName,
                TaskPriority = taskPriority,
                TaskStatus = taskStatus,
                TaskDeadline = taskDeadline,
                TaskDetails = taskDetails
            };

            string sql = @"insert into dbo.Tasks (TaskName, TaskPriority, TaskStatus, TaskDeadline, TaskDetails) values (@TaskName, @TaskPriority, @TaskStatus, @TaskDeadline, @TaskDetails)";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<DataLibrary.Models.TaskModel> LoadTasks()
        {
            string sql = "select * from dbo.Tasks";
            return SqlDataAccess.LoadData<DataLibrary.Models.TaskModel>(sql);
        }
    }
}
