using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.Entities;
using BLL.Interfaces;
using AutoMapper;
using DAL;

namespace BLL
{
    public class TaskBL : IBlTaskServicer
    {
        private readonly IUnitOfWork database = new UnitOfWork();

        public IMapper Mapper { get; set; }

        public async Task<IEnumerable<ToDoTask>> GetTasks()
        {
            var tasks = await database.TasksRepository.GetAll();
            return Mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

        public async Task<ToDoTask> GetTaskById(int taskId)
        {
            var task = await database.TasksRepository.GetById(taskId);
            return Mapper.Map<ToDoTask>(task);
        }

        public async Task DeleteTask(int taskId)
        {
           await database.TasksRepository.Delete(taskId);
            database.Save();
        }

        public async Task CreateTask(ToDoTask task)
        {
            await database.TasksRepository.Add(Mapper.Map<DAL.Entities.ToDoTask>(task));
            database.Save();
        }

        public async Task UpdateTask(int taskId)
        {
            await database.TasksRepository.Update(taskId);
            database.Save();
        }
    }
}
