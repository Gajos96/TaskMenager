using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMenager.Models;
using TaskMenager.Repositories;

namespace TaskMenager.Controllers
{
    public class TaskControllers : Controller
    {
        private readonly ITaskRepositories _taskRepositories;

        public TaskControllers(ITaskRepositories taskRepositories)
        {
            _taskRepositories = taskRepositories;
        }

        // GET: TaskControllers
        public ActionResult Index()
        {
            return View(_taskRepositories.GetAllActive());
        }

        // GET: TaskControllers/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepositories.Get(id));
        }

        // GET: TaskControllers/Create
        public ActionResult Create()
        {
            return View( new TaskModel());
        }

        // POST: TaskControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskmodel)
        {
            _taskRepositories.Add(taskmodel);
            return RedirectToAction(nameof(Index));
        }

        // GET: TaskControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepositories.Get(id));
        }

        // POST: TaskControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskmotel)
        {
            _taskRepositories.Update(id, taskmotel);
                return RedirectToAction(nameof(Index));
        }

        // GET: TaskControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepositories.Get(id));
        }

        // POST: TaskControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taksmodel)
        {
            _taskRepositories.Delete(id);
                return RedirectToAction(nameof(Index));
        }

        // Get : TaskControllers/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepositories.Get(id);
            task.Done = true;
            _taskRepositories.Update(id, task);
            return RedirectToAction(nameof(Index));
        }


    }
}
