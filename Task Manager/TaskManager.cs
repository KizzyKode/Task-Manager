using System;
using System.Collections.Generic;
using System.IO;

namespace Task_Manager
{
    
    class TaskManager
    {
        static Dictionary<string, Task> taskDictionary = new Dictionary<string, Task>();
        const string FilePath = "tasks.txt";

        static void Main()
        {
            LoadTasksFromFile();

            while (true)
            {
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ViewTasks();
                        break;

                    case "3":
                        UpdateTask();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        SaveTasksToFile();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task code (2 digits and a letter, e.g., 01A): ");
            string taskCode = Console.ReadLine().ToUpper();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-mm-dd): ");
            }

            Console.Write("Enter task priority (Low, Medium, High): ");
            TaskPriority priority;
            while (!Enum.TryParse(Console.ReadLine(), true, out priority) || !Enum.IsDefined(typeof(TaskPriority), priority))
            {
                Console.WriteLine("Invalid priority. Please enter Low, Medium, or High.");
            }

            Task newTask = new Task(description, dueDate, priority);
            taskDictionary.Add(taskCode, newTask);

            Console.WriteLine("Task added successfully!");
        }

        static void ViewTasks()
        {
            Console.WriteLine("Task List:");
            if (taskDictionary.Count > 0)
            {
                foreach (var task in taskDictionary)
                {
                    Console.WriteLine($"- {task.Key}: {task.Value.Description} (Due Date: {task.Value.DueDate.ToShortDateString()}, Priority: {task.Value.Priority}, Status: {task.Value.Status})");
                }
            }
            else
            {
                Console.WriteLine("No tasks available.");
            }
        }

        static void UpdateTask()
        {
            Console.Write("Enter the task code to update: ");
            string taskCode = Console.ReadLine().ToUpper();

            if (taskDictionary.TryGetValue(taskCode, out Task taskToUpdate))
            {
                Console.Write("Enter new task description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    taskToUpdate.Description = newDescription;
                }

                Console.Write("Enter new due date (yyyy-mm-dd) (leave blank to keep current): ");
                string newDueDateString = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDueDateString) && DateTime.TryParse(newDueDateString, out DateTime newDueDate))
                {
                    taskToUpdate.DueDate = newDueDate;
                }

                Console.Write("Enter new task priority (Low, Medium, High) (leave blank to keep current): ");
                string newPriorityString = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriorityString) && Enum.TryParse(newPriorityString, true, out TaskPriority newPriority) && Enum.IsDefined(typeof(TaskPriority), newPriority))
                {
                    taskToUpdate.Priority = newPriority;
                }

                Console.Write("Mark task as done or pending? (done/pending/leave blank to keep current): ");
                string statusInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(statusInput))
                {
                    if (Enum.TryParse(statusInput, true, out TaskStatus newStatus) && Enum.IsDefined(typeof(TaskStatus), newStatus))
                    {
                        taskToUpdate.Status = newStatus;
                    }
                    else
                    {
                        Console.WriteLine("Invalid status. Task status remains unchanged.");
                    }
                }

                Console.WriteLine("Task updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task code.");
            }
        }

        static void DeleteTask()
        {
            Console.Write("Enter the task code to delete: ");
            string taskCode = Console.ReadLine().ToUpper();

            if (taskDictionary.ContainsKey(taskCode))
            {
                taskDictionary.Remove(taskCode);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task code.");
            }
        }

        static void SaveTasksToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var task in taskDictionary)
                {
                    writer.WriteLine($"{task.Key},{task.Value.Description},{task.Value.DueDate},{task.Value.Priority},{task.Value.Status}");
                }
            }

            Console.WriteLine("Tasks saved to file.");
        }

        static void LoadTasksFromFile()
        {
            if (File.Exists(FilePath))
            {
                taskDictionary.Clear();

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 5)
                        {
                            string taskCode = parts[0].ToUpper();
                            string description = parts[1];
                            DateTime dueDate = DateTime.Parse(parts[2]);
                            TaskPriority priority = Enum.Parse<TaskPriority>(parts[3], true);
                            TaskStatus status = Enum.Parse<TaskStatus>(parts[4], true);

                            Task task = new Task(description, dueDate, priority);
                            task.Status = status;

                            taskDictionary.Add(taskCode, task);
                        }
                    }
                }

                Console.WriteLine("Tasks loaded from file.");
            }
        }
    }

    enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    enum TaskStatus
    {
        Pending,
        Done
    }


}

