using SmartTodoApp.Models;
using System;
using System.Collections.Generic;

namespace SmartTodoApp.Views
{
    public interface IMainView
    {
        event Action? AddTaskRequested;
        event Action? DeleteTaskRequested;
        event Action? SortByNameRequested;
        event Action? SortByStatusRequested;
        int? GetSelectedTaskId();
        string NewTaskTitle { get; }

        void DisplayTasks(List<TaskItem> tasks);
        void UpdateStatistics(int total, int completed);
        void ClearTaskInput();
    }
}