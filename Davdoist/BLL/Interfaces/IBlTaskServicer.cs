using BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlTaskServicer : IBaseServicer
    {
        public IEnumerable<ToDoTask> GetTasks();

        public IEnumerable<ToDoTask> GetFolderTasks(int folderId);

        public ToDoTask GetTaskById(int taskId);

        public void DeleteTask(int taskId);

        public void Deletetask(ToDoTask task);

        public void CreateTask(Task task);

    }
}
