using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBlTaskServicer taskBl;
        private readonly IBlFolderServicer folderBl;

        public ToDoTaskController(IMapper mapper, IBlTaskServicer blServicer, IBlFolderServicer blFolder)
        {
            taskBl = blServicer;
            this.folderBl = blFolder;

            this.mapper = mapper;
            folderBl.Mapper = mapper;
            taskBl.Mapper = this.mapper;
        }

        // GET: ToDoTaskController
        public async Task<ActionResult> Index()
        {
            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(await taskBl.GetTasks());
            return View(tasks);
        }

        // GET: ToDoTaskController/Details/5
        public async Task<ActionResult> Details(int? toDoTaskId)
        {
            if (toDoTaskId == null)
            {
                return NotFound();
            }

            ToDoTask task = mapper.Map<ToDoTask>(await taskBl.GetTaskById((int)toDoTaskId));

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // TODO: Edit an create one method Create/Edit

        // GET: ToDoTaskController/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<Folder> folders = mapper.Map<IEnumerable<Folder>>(await folderBl.GetFolders());
            return View(folders);
        }

        // POST: ToDoTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ToDoTask task = new ToDoTask()
                    {
                        Header = toDoTask.Header,
                        Description = toDoTask.Description,
                        Date = toDoTask.Date,
                        Priority = toDoTask.Priority,
                        IsCompleted = toDoTask.IsCompleted,
                        FolderId = toDoTask.FolderId.HasValue ? toDoTask.FolderId.Value : null
                    };
                    if (toDoTask.FolderId.HasValue)
                    {
                        Folder folder = mapper.Map<Folder>(folderBl.GetFolderById((int)toDoTask.FolderId));
                        folder.Tasks.Add(task);
                        await folderBl.UpdateFolder(folder.Id);
                    }

                    await taskBl.CreateTask(mapper.Map<BLL.Entities.ToDoTask>(task));

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
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

            int taskId = taskBl.GetTaskById((int)toDoTaskid).Id;
            taskBl.DeleteTask(taskId);

            return View();
        }

        // POST: ToDoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int ToDoTaskId)
        {
            BLL.Entities.ToDoTask task = await taskBl.GetTaskById(ToDoTaskId);
            await taskBl.DeleteTask(task.Id);

            return RedirectToAction(nameof(Index));

        }
    }
}
