
# Task Manager Console Application

## Overview

This is a console-based Task Manager application written in C#. It allows users to add, view, update, and delete tasks with features like task descriptions, due dates, priorities, and statuses.

## Features

- **Add Task:** Create a new task by providing a task code, description, due date, priority, and status.
- **View Tasks:** Display a list of tasks with their details, including task code, description, due date, priority, and status.
- **Update Task:** Modify existing tasks by entering the task code and updating the description, due date, priority, or status.
- **Delete Task:** Remove a task from the list by entering the task code.

## Usage

1. **Add Task:** Select option 1 from the menu, and follow the prompts to enter task details.
2. **View Tasks:** Choose option 2 to see the list of tasks.
3. **Update Task:** Select option 3 and provide the task code to update its details.
4. **Delete Task:** Choose option 4 and enter the task code to delete the task.
5. **Exit:** To exit the program, choose option 5.

## Task Code Format

The task code consists of two digits and a letter (e.g., 01A). Task codes are case-insensitive, and you can use small or capital letters.

## Priority and Status

Both priority and status inputs are case-insensitive. Valid options for priority are Low, Medium, and High. For status, use Done or Pending.

## Local Storage

Tasks are stored locally, allowing you to close and reopen the program while retaining your task data.

## Instructions

1. Clone the repository to your local machine.
2. Open the solution in your preferred C# IDE (e.g., Visual Studio).
3. Build and run the program.
4. Follow the on-screen instructions to manage tasks.

## Example

```csharp
// Create a task
1. Add Task
   Enter task code: 01A
   Enter task description: Complete project report
   Enter due date (yyyy-mm-dd): 2024-03-15
   Enter task priority (Low, Medium, High): Medium
   Mark task as done or pending? (done/pending): Pending

// View tasks
2. View Tasks
   Task List:
   - 01A: Complete project report (Due Date: 2024-03-15, Priority: Medium, Status: Pending)

// Update task
3. Update Task
   Enter the task code to update: 01A
   Enter new task description (leave blank to keep current): Update project report details
   Enter new due date (yyyy-mm-dd) (leave blank to keep current): 2024-03-20
   Enter new task priority (Low, Medium, High) (leave blank to keep current): High
   Mark task as done or pending? (done/pending/leave blank to keep current): Done

// Delete task
4. Delete Task
   Enter the task code to delete: 01A
   Task deleted successfully!
```

