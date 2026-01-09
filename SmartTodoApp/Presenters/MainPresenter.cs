using SmartTodoApp.Models;
using SmartTodoApp.Services;
using SmartTodoApp.Views;
using SmartTodoApp.Strategy;
using System.Linq;
using System.Collections.Generic;

namespace SmartTodoApp.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly Singleton _repository;
        private ISortStrategy _sortStrategy;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _repository = Singleton.Instance;
            _sortStrategy = new SortByNameStrategy();

            _view.AddTaskRequested += OnAddTask;
            _view.DeleteTaskRequested += OnDeleteTask;
            _view.SortByNameRequested += OnSortByNameRequested;
            _view.SortByStatusRequested += OnSortByStatusRequested;
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _repository.GetAllTasks();
            var sortedTasks = _sortStrategy.Sort(tasks);
            _view.DisplayTasks(sortedTasks);
            
            int total = tasks.Count;
            int completed = tasks.Count(t => t.IsCompleted);
            _view.UpdateStatistics(total, completed);
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

        private void OnDeleteTask()
        {
            var taskId = _view.GetSelectedTaskId();
            if (taskId.HasValue)
            {
                _repository.DeleteTask(taskId.Value);
                LoadTasks();
            }
        }

        private void OnSortByNameRequested()
        {
            _sortStrategy = new SortByNameStrategy();
            LoadTasks();
        }
        
        private void OnSortByStatusRequested()
        {
            _sortStrategy = new SortByStatusStrategy();
            LoadTasks();
        }
    }
}