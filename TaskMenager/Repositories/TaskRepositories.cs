using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMenager.Models;

namespace TaskMenager.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {
        /// <summary>
        /// Przetrzymywanie zmiennych
        /// </summary>
        private readonly TaskMannegerContext _context;
        public TaskRepositories (TaskMannegerContext context)
        {
            _context = context; 
        }


        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }


        public void Delete(int TaskId)
        {
            var result = _context.Tasks.SingleOrDefault(o => o.TaskId == TaskId);
            if(result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }
        }
        
        public TaskModel Get(int taskId)
            => _context.Tasks.SingleOrDefault(o => o.TaskId == taskId);

        public IQueryable<TaskModel> GetAllActive()
            => _context.Tasks.Where(x => !x.Done);

        public void Update(int taskId, TaskModel taskModel)
        {
            var result = _context.Tasks.SingleOrDefault(o => o.TaskId == taskId);
            if (result != null)
            {
                result.Name = taskModel.Name;
                result.Description = taskModel.Description;
                result.Done = taskModel.Done;
                _context.SaveChanges();
            }
        }
    }
}
