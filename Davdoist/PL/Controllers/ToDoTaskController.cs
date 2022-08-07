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
                    // TODO: Add folderId/Folder to see where he's contains
                    ToDoTask task = new ToDoTask()
                    {
                        Header = toDoTask.Header,
                        Description = toDoTask.Description,
                        Date = toDoTask.Date,
                        Priority = toDoTask.Priority,
                        IsCompleted = toDoTask.IsCompleted,
                        FolderId = toDoTask.FolderId.HasValue ? toDoTask.FolderId.Value : null
                    };

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

        //GET: ToDoTaskController/Edit/5
        public async Task<ActionResult> Edit(int taskId)
        {
            ViewBag.Folders = mapper.Map<IEnumerable<Folder>>(await folderBl.GetFolders());

            ToDoTask toDoTask = mapper.Map<ToDoTask>(await taskBl.GetTaskById(taskId));

            return View(toDoTask);
        }

        // POST: ToDoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int taskId, ToDoTask toDoTask)
        {
            // TODO: передать в таксАйди айди с представления
            if (ModelState.IsValid)
            {
                try
                {
                    ToDoTask task = mapper.Map<ToDoTask>(await taskBl.GetTaskById(taskId));

                    task.Header = toDoTask.Header;
                    task.FolderId = toDoTask.FolderId;
                    task.Description = toDoTask.Description;
                    task.Date = toDoTask.Date;
                    task.Priority = toDoTask.Priority;
                    task.IsCompleted = toDoTask.IsCompleted;

                    await taskBl.UpdateTask(mapper.Map<BLL.Entities.ToDoTask>(task));

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return View();

        }

        // GET: ToDoTaskController/Delete/5
        public async Task<ActionResult> Delete(int? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }

            ToDoTask toDoTask = mapper.Map<ToDoTask>(await taskBl.GetTaskById((int)taskId));

            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // POST: ToDoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int taskId)
        {
            try
            {
                BLL.Entities.ToDoTask task = await taskBl.GetTaskById(taskId);

                if (task == null)
                {
                    throw new NullReferenceException();
                }

                await taskBl.DeleteTask(task.Id);
            }
            catch (NullReferenceException)
            {
                NotFound();
            }
            catch (Exception)
            {
                NoContent();
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
