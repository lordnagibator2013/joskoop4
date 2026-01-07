using System;

namespace MainWindow;

class Task
{
    public int id;
    public string title;
    public bool isDone;

    private List<TaskItem> _tasks = new();
    private int _nextId = 1;

    private void AddTask_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskInput.Text))
        {
            _tasks.Add(new TaskItem
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