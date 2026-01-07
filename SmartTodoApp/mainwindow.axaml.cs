using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace SmartTodoApp.Views
{
    public partial class MainWindow : Window
    {
        public class Task
        {
            public int id { get; set; }
            public string title { get; set; } = "";
            public bool isDone { get; set; }
        }

        private List<Task> _tasks = new();
        private int _nextId = 1;

        public MainWindow()
        {
            InitializeComponent();
            
            _tasks.Add(new Task { id = _nextId++, title = "Тестовая задача", isDone = false });
            UpdateTaskList();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                _tasks.Add(new Task
                {
                    id = _nextId++,
                    title = TaskInput.Text,
                    isDone = false
                });

                TaskInput.Text = "";
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = _tasks;
        }
    }
}