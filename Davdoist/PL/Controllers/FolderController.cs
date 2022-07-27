using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Collections.Generic;


namespace PL.Controllers
{
    public class FolderController : Controller
    {
        private readonly IBlFolderServicer bl;
        private readonly IMapper mapper;

        public FolderController(IMapper mapper, IBlFolderServicer blServicer)
        {
            bl = blServicer;
            this.mapper = mapper;
            bl.Mapper = this.mapper;
        }

        // GET: FoldersController
        public ActionResult Index()
        {
            IEnumerable<Folder> folders = mapper.Map<IEnumerable<Folder>>(bl.GetFolders());
            return View(folders);
        }

        // GET: FoldersController/Details/5
        public ActionResult Details(int? folderId)
        {
            if(folderId == null)
            {
                return NotFound();
            }

            Folder folder = mapper.Map<Folder>(bl.GetFolderById((int)folderId));

            return View(folder);
        }

        // GET: FoldersController/Create
        public ActionResult Create()
        {
            return View();
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

            int folderDelId = bl.GetFolderById((int)folderId).Id;
            bl.DeleteFolder(folderDelId);

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
