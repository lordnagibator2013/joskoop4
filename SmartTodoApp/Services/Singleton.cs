using SmartTodoApp.Models;
using System.Collections.Generic;

namespace SmartTodoApp.Services
{
    public class Singleton
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
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>(_tasks);
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}