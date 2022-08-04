using AutoMapper;
using BLL.Entities;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FolderBL : IBlFolderServicer
    {
        private readonly IUnitOfWork database = new UnitOfWork();

        public IMapper Mapper { get; set; }

        public IEnumerable<ToDoTask> GetFolderTasks(int folderId)
        {
            var tasks = database.TasksRepository.GetAllTasksById(folderId);
            return Mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

        public IEnumerable<Folder> GetFolders()
        {
            var folders = database.FoldersRepository.GetAll();
            return Mapper.Map<IEnumerable<Folder>>(folders);
        }

        public Folder GetFolderById(int folderId)
        {
            var folder = database.FoldersRepository.GetById(folderId);
            return Mapper.Map<Folder>(folder);
        }

        public void DeleteFolder(int folderId)
        {
            database.FoldersRepository.Delete(folderId);
            database.Save();
        }

        public void CreateFolder(Folder folder)
        {
            database.FoldersRepository.Add(Mapper.Map<DAL.Entities.Folder>(folder));
            database.Save();
        }

        public void UpdateFolder(int folderId)
        {
            database.FoldersRepository.Update(folderId);
            database.Save();
        }
    }
}
