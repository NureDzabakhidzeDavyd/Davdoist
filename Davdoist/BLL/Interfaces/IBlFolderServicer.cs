using BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlFolderServicer : IBaseServicer
    {
        public  Task<IEnumerable<Folder>> GetFolders();

        public Task<Folder> GetFolderById(int folderId);

        public Task DeleteFolder(int folderId);

        public Task<IEnumerable<ToDoTask>> GetFolderTasks(int folderId);

        public Task CreateFolder(Folder folder);

        public Task UpdateFolder(Folder folder);
    }
}
