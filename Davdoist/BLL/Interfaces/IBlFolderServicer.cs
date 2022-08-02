using BLL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBlFolderServicer : IBaseServicer
    {
        public IEnumerable<Folder> GetFolders();

        public Folder GetFolderById(int folderId);

        public void DeleteFolder(int folderId);

        public IEnumerable<ToDoTask> GetFolderTasks(int folderId);
    }
}
