using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Collections.Generic;

namespace PL.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBlTaskServicer bl;

        public ToDoTaskController(IMapper mapper, IBlTaskServicer blServicer)
        {
            bl = blServicer;

            this.mapper = mapper;
            bl.Mapper = this.mapper;
        }

        // GET: ToDoTaskController
        public ActionResult Index()
        {
            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(bl.GetTasks());
            return View(tasks);
        }

        // GET: ToDoTaskController/Details/5
        public ActionResult Details(int? toDoTaskId)
        {
            if (toDoTaskId == null)
            {
                return NotFound();
            }

            ToDoTask task = mapper.Map<ToDoTask>(bl.GetTaskById((int)toDoTaskId));

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // TODO: Edit an create one method Create/Edit

        // GET: ToDoTaskController/Create
        public ActionResult Create(ToDoTask task)
        {

            return View();
        }

        // POST: ToDoTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoTaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoTaskController/Delete/5
        public ActionResult Delete(int? toDoTaskid)
        {
            if (toDoTaskid == null)
            {
                return NotFound();
            }

            int taskId = bl.GetTaskById((int)toDoTaskid).Id;
            bl.DeleteTask(taskId);

            return View();
        }

        // POST: ToDoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ToDoTaskId)
        {
            BLL.Entities.ToDoTask task = bl.GetTaskById(ToDoTaskId);
            bl.Deletetask(task);

            return RedirectToAction(nameof(Index));

        }
    }
}
