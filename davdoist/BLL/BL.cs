using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.Entities;
using BLL.Interfaces;
using AutoMapper;
using DAL;

namespace BLL
{
    public class BL : IBlTaskServicer, IBlFolderServicer
    {
        private readonly IUnitOfWork database = new UnitOfWork();

        public IMapper Mapper { get; set; }

        public IEnumerable<ToDoTask> GetTasks()
        {
            var tasks = database.TasksRepository.GetAll();
            return Mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

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

        public ToDoTask GetTaskById(int taskId)
        {
            var task = database.TasksRepository.GetById(taskId);
            return Mapper.Map<ToDoTask>(task);
        }

        public void DeleteTask(int taskId)
        {
            database.TasksRepository.Delete(taskId);
            database.Save();
        }

        public void CreateTask(Task task)
        {
            database.TasksRepository.Add(Mapper.Map<DAL.Entities.ToDoTask>(task));
            database.Save();
        }

        public void Deletetask(ToDoTask task)
        {
            database.TasksRepository.Delete(Mapper.Map<DAL.Entities.ToDoTask>(task));
            database.Save();
        }

        public void DeleteFolder(int folderId)
        {
            database.FoldersRepository.Delete(folderId);
            database.Save();
        }
    }
}
