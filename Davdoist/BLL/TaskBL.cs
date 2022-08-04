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

        public IEnumerable<ToDoTask> GetTasks()
        {
            var tasks = database.TasksRepository.GetAll();
            return Mapper.Map<IEnumerable<ToDoTask>>(tasks);
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

        public void CreateTask(ToDoTask task)
        {
            database.TasksRepository.Add(Mapper.Map<DAL.Entities.ToDoTask>(task));
            database.Save();
        }

        public void Deletetask(ToDoTask task)
        {
            database.TasksRepository.Delete(Mapper.Map<DAL.Entities.ToDoTask>(task));
            database.Save();
        }
      
        public void UpdateTask(int taskId)
        {
            database.TasksRepository.Update(taskId);
            database.Save();
        }
    }
}
