using SmartTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartTodoApp.Services
{
    public class StatisticsService
    {
        public (int Total, int Completed) CalculateStatistics(List<TaskItem> tasks)
        {
            int total = tasks.Count;
            int completed = tasks.Count(t => t.IsCompleted);
            return (total, completed);
        }
    }
}