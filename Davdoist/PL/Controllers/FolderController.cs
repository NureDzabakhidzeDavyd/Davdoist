using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PL.Models;
using System.Collections.Generic;


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
        public ActionResult Index()
        {
            IEnumerable<Folder> folders = mapper.Map<IEnumerable<Folder>>(blFolder.GetFolders());
            return View(folders);
        }

        // GET: FoldersController/Details/5
        public ActionResult Details(int? folderId)
        {
            if(folderId == null)
            {
                return NotFound();
            }

            Folder folder = mapper.Map<Folder>(blFolder.GetFolderById((int)folderId));

            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(blFolder.GetFolderTasks((int)folderId));

            folder.Tasks = tasks.ToList();

            return View(folder);
        }

        // GET: FoldersController/Create
        public ActionResult Create()
        {
            IEnumerable<ToDoTask> tasks = mapper.Map<IEnumerable<ToDoTask>>(blTask.GetTasks());
            return View(tasks);
        }

        // POST: FoldersController/Create
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

        // GET: FoldersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoldersController/Edit/5
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

        // GET: FoldersController/Delete/5
        public ActionResult Delete(int? folderId)
        {
            if(folderId == null)
            {
                return NotFound();
            }

            int folderDelId = blFolder.GetFolderById((int)folderId).Id;
            blFolder.DeleteFolder(folderDelId);

            return View();
        }

        // POST: FoldersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
