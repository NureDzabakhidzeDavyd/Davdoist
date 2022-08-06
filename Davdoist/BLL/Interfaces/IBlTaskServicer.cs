using BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlTaskServicer : IBaseServicer
    {
        public Task<IEnumerable<ToDoTask>> GetTasks();

        public  Task<ToDoTask> GetTaskById(int taskId);

        public Task DeleteTask(int taskId);

        public Task CreateTask(ToDoTask task);

        public Task UpdateTask(ToDoTask task);
    }
}
