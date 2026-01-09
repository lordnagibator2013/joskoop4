using Avalonia.Controls;
using Avalonia.Interactivity;
using SmartTodoApp.Models;
using SmartTodoApp.Presenters;
using SmartTodoApp.Strategy;
using System;
using System.Collections.Generic;

namespace SmartTodoApp.Views
{
    public partial class MainWindow : Window, IMainView
    {
        public event Action? AddTaskRequested;
        public event Action? DeleteTaskRequested;
        public event Action? SortByNameRequested;
        public event Action? SortByStatusRequested;
        public string NewTaskTitle => TaskInput.Text ?? string.Empty;
        
        private MainPresenter _presenter;

        public MainWindow()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        public void DisplayTasks(List<TaskItem> tasks)
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = tasks;
        }

        public void ClearTaskInput()
        {
            TaskInput.Text = "";
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            AddTaskRequested?.Invoke();
        }

        public int? GetSelectedTaskId()
        {
            if (TasksList.SelectedItem is Models.TaskItem task)
            {
                return task.Id;
            }
            return null;
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            DeleteTaskRequested?.Invoke();
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            SortByNameRequested?.Invoke();
        }

        private void SortByStatus(object sender, RoutedEventArgs e)
        {
            SortByStatusRequested?.Invoke();
        }
        
        public void UpdateStatistics(int total, int completed)
        {
            if (StatsText != null)
            {
                StatsText.Text = $"Всего задач: {total} | Выполнено: {completed}";
            }
        }
    }
}