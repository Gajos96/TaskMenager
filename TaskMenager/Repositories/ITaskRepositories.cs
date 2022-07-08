using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMenager.Models;

namespace TaskMenager.Repositories
{
    public interface ITaskRepositories
    {
        TaskModel Get(int taskId);
        IQueryable<TaskModel> GetAllActive();
        void Add(TaskModel task);
        void Update(int taskId ,  TaskModel taskModel);
        void Delete(int TaskId);


    }
}
