CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskName] NVARCHAR(50) NOT NULL, 
    [TaskPriority] NCHAR(10) NOT NULL, 
    [TaskStatus] NCHAR(10) NOT NULL, 
    [TaskDeadline] DATETIME NOT NULL, 
    [TaskDetails] NVARCHAR(MAX) NULL
)
