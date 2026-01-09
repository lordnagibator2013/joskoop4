using SmartTodoApp.Interfaces;
using SmartTodoApp.Models;
using SmartTodoApp.Services;
using SmartTodoApp.Strategy;
using SmartTodoApp.Views;
using System.Collections.Generic;

namespace SmartTodoApp.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IRepository _repository;
        private readonly SortManager _sortManager;
        private readonly StatisticsService _statisticsService;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _repository = Singleton.Instance;
            _sortManager = new SortManager();
            _statisticsService = new StatisticsService();

            _view.AddTaskRequested += OnAddTask;
            _view.DeleteTaskRequested += OnDeleteTask;
            _view.SortByNameRequested += OnSortByNameRequested;
            _view.SortByStatusRequested += OnSortByStatusRequested;
            
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _repository.GetAllTasks();
            var sortedTasks = _sortManager.SortTasks(tasks);
            _view.DisplayTasks(sortedTasks);
            
            var stats = _statisticsService.CalculateStatistics(tasks);
            _view.UpdateStatistics(stats.Total, stats.Completed);
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
            _sortManager.SetStrategy(new SortByNameStrategy());
            LoadTasks();
        }
        
        private void OnSortByStatusRequested()
        {
            _sortManager.SetStrategy(new SortByStatusStrategy());
            LoadTasks();
        }
    }
}