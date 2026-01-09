using SmartTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartTodoApp.Strategy
{
    public class SortByStatusStrategy : ISortStrategy
    {
        public List<TaskItem> Sort(List<TaskItem> tasks)
        {
            return tasks.OrderBy(t => t.IsCompleted).ToList();
        }
    }
}