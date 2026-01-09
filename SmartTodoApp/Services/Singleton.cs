using SmartTodoApp.Interfaces;
using SmartTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartTodoApp.Services
{
    public class Singleton : IRepository
    {
        private static Singleton _instance;
        private List<TaskItem> _tasks;
        private int _nextId = 1;

        private Singleton()
        {
            _tasks = new List<TaskItem>();
        }

        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>(_tasks);
        }
    }
}