using SmartTodoApp.Models;
using System;
using System.Collections.Generic;

namespace SmartTodoApp.Views
{
    public interface IMainView
    {
        event Action AddTaskRequested;
        
        string NewTaskTitle { get; }
        
        void DisplayTasks(List<TaskItem> tasks);
        void ClearTaskInput();
    }
}