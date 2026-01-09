using SmartTodoApp.Models;
using System.Collections.Generic;

namespace SmartTodoApp.Strategy
{
    public interface ISortStrategy
    {
        List<TaskItem> Sort(List<TaskItem> tasks);
    }
}