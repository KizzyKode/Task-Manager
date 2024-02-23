using System;
namespace Task_Manager
{
    class Task
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string description, DateTime dueDate, TaskPriority priority)
        {
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = TaskStatus.Pending;
        }
    }


}

