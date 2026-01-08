using SmartTodoApp.Models;
using SmartTodoApp.Services;
using SmartTodoApp.Views;
using System.Collections.Generic;

namespace SmartTodoApp.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly Singleton _repository;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _repository = Singleton.Instance;
            
            _view.AddTaskRequested += OnAddTask;
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _repository.GetAllTasks();
            _view.DisplayTasks(tasks);
        }

        private void OnAddTask()
        {
            if (!string.IsNullOrWhiteSpace(_view.NewTaskTitle))
            {
                var task = new TaskItem 
                { 
                    Title = _view.NewTaskTitle, 
                    IsCompleted = false 
                };
                
                _repository.AddTask(task);
                LoadTasks();
                _view.ClearTaskInput();
            }
        }
    }
}