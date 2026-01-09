using SmartTodoApp.Models;
using SmartTodoApp.Strategy;
using System.Collections.Generic;

namespace SmartTodoApp.Services
{
    public class SortManager
    {
        private ISortStrategy _currentStrategy;

        public SortManager()
        {
            _currentStrategy = new SortByNameStrategy();
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public List<TaskItem> SortTasks(List<TaskItem> tasks)
        {
            return _currentStrategy.Sort(tasks);
        }
    }
}