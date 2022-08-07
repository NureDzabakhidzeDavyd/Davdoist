using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PL.Controllers
{
    public class FolderController : Controller
    {
        private readonly IBlFolderServicer blFolder;
        private readonly IBlTaskServicer blTask;
        private readonly IMapper mapper;

        public FolderController(IMapper mapper, IBlFolderServicer blServicer, IBlTaskServicer blTaskServicer)
        {
            blFolder = blServicer;
            blTask = blTaskServicer;

            this.mapper = mapper;
            blTask.Mapper = this.mapper;
            blFolder.Mapper = this.mapper;
        }

        // GET: FoldersController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Folder> folders = mapper.Map<IEnumerable<Folder>>(await blFolder.GetFolders());
            return View(folders);
        }

        // GET: FoldersController/Details/5
        public async Task<ActionResult> Details(int? folderId)
        {
            if (folderId == null)
            {
                return NotFound();
            }

            List<Folder> folders = new List<Folder>();
            Folder folder = mapper.Map<Folder>(await blFolder.GetFolderById((int)folderId));
            folders.Add(folder);

            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(await blFolder.GetFolderTasks((int)folderId));

            PL.ViewModels.TaskAndFolder taskAndFolder = new ViewModels.TaskAndFolder()
            {
                Folders = folders,
                Tasks = tasks
            };

            return View(taskAndFolder);
        }

        // GET: FoldersController/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(await blTask.GetTasks()).Where(task => task.FolderId == null);
            return View(tasks);
        }

        // POST: FoldersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Folder folder = new Folder()
                    {
                        Name = form["Name"]
                    };

                   await blFolder.CreateFolder(mapper.Map<BLL.Entities.Folder>(folder));

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: FoldersController/Edit/5
        public async Task<ActionResult> Edit(int folderId)
        {
            ViewBag.Folder = mapper.Map<Folder>(await blFolder.GetFolderById(folderId));

            return View();
        }

        // POST: FoldersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Folder folder)
        {
            try
            {
                await blFolder.UpdateFolder(mapper.Map<BLL.Entities.Folder>(folder));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoldersController/Delete/5
        public async Task<ActionResult> Delete(int? folderId)
        {
            if(folderId == null)
            {
                return NotFound();
            }

            Folder folder = mapper.Map<Folder>(await blFolder.GetFolderById((int)folderId));

            if(folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // POST: FoldersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? folderId, IFormCollection collection)
        {
                if (folderId == null)
                {
                    return NotFound();
                }
            try
            {

                int? folderDelId = mapper.Map<Folder>(await blFolder.GetFolderById((int)folderId)).Id;

                if(folderDelId == null)
                {
                    return NotFound();
                }

                await blFolder.DeleteFolder((int)folderDelId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
