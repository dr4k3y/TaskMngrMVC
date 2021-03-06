﻿using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class TaskProcessor
    {
        public static int CreateTask(string taskName, Priority taskPriority, Status taskStatus, DateTime taskDeadline, string taskDetails, int userId)
        {
            DataLibrary.Models.TaskModel data = new Models.TaskModel
            {
                TaskName = taskName,
                TaskPriority = taskPriority,
                TaskStatus = taskStatus,
                TaskDeadline = taskDeadline,
                TaskDetails = taskDetails,
                UserId = userId
            };

            string sql = @"insert into dbo.Tasks (TaskName, TaskPriority, TaskStatus, TaskDeadline, TaskDetails, UserId) values (@TaskName, @TaskPriority, @TaskStatus, @TaskDeadline, @TaskDetails, @UserId)";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int DeleteTask(int id)
        {
            DataLibrary.Models.TaskModel data = new Models.TaskModel
            {
                Id = id
            };
            string sql = @"delete from dbo.Tasks where Id=@Id";
            return SqlDataAccess.DeleteData(sql, data);
        }
        public static int EditTask(int id, string taskName, Priority taskPriority, Status taskStatus, DateTime taskDeadline, string taskDetails)
        {
            DataLibrary.Models.TaskModel data = new Models.TaskModel
            {
                Id=id,
                TaskName = taskName,
                TaskPriority = taskPriority,
                TaskStatus = taskStatus,
                TaskDeadline = taskDeadline,
                TaskDetails = taskDetails
            };

            string sql = @"update dbo.Tasks set TaskName=@TaskName, TaskPriority=@TaskPriority, TaskStatus=@TaskStatus, TaskDeadline=@TaskDeadline, TaskDetails=@TaskDetails where Id=@Id";
            return SqlDataAccess.EditData(sql, data);
        }
        public static List<DataLibrary.Models.TaskModel> LoadTasks(int Id)
        {
            TaskModel data = new TaskModel
            {
                UserId=Id
            };
            string sql = "select * from dbo.Tasks where UserId=@UserId";
            return SqlDataAccess.LoadData<DataLibrary.Models.TaskModel>(sql, data);
        }
    }
}
