using BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlTaskServicer : IBaseServicer
    {
        public IEnumerable<ToDoTask> GetTasks();

        public ToDoTask GetTaskById(int taskId);

        public void DeleteTask(int taskId);

        public void Deletetask(ToDoTask task);

        public void CreateTask(ToDoTask task);

        public void UpdateTask(int taskId);
    }
}
