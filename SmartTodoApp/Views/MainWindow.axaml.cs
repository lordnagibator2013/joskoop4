using Avalonia.Controls;
using Avalonia.Interactivity;
using SmartTodoApp.Models;
using SmartTodoApp.Presenters;
using System;
using System.Collections.Generic;

namespace SmartTodoApp.Views
{
    public partial class MainWindow : Window, IMainView
    {
        public event Action AddTaskRequested;
        public string NewTaskTitle => TaskInput.Text;
        
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

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskRequested?.Invoke();
        }
    }
}