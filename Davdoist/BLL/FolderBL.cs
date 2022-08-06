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

        public async Task<IEnumerable<ToDoTask>> GetFolderTasks(int folderId)
        {
            var tasks = await database.TasksRepository.GetAllTasksById(folderId);
            return Mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

        public async Task<IEnumerable<Folder>> GetFolders()
        {
            var folders = await database.FoldersRepository.GetAll();
            return Mapper.Map<IEnumerable<Folder>>(folders);
        }

        public async Task<Folder> GetFolderById(int folderId)
        {
            var folder = await database.FoldersRepository.GetById(folderId);
            return Mapper.Map<Folder>(folder);
        }

        public async Task DeleteFolder(int folderId)
        {
           await database.FoldersRepository.Delete(folderId);

           await  database.Save();
        }

        public async Task CreateFolder(Folder folder)
        {
           await database.FoldersRepository.Add(Mapper.Map<DAL.Entities.Folder>(folder));
            await database.Save();
        }

        public async Task UpdateFolder(Folder folder)
        {
           database.FoldersRepository.Update(Mapper.Map<DAL.Entities.Folder>(folder));
           await database.Save();
        }
    }
}
