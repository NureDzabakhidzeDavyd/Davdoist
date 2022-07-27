using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL._Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TaskAndFolderContext context;
        private readonly DbSet<TEntity> dBSet;

        public GenericRepository(TaskAndFolderContext context)
        {
            this.context = context;
            dBSet = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dBSet.Add(entity);
        }

        public void Delete(int id)
        {
            var delEntity = dBSet.Find(id);
            dBSet.Remove(delEntity);
        }

        public void Delete(TEntity entityToDel)
        {
            if (context.Entry(entityToDel).State == EntityState.Detached)
            {
                dBSet.Attach(entityToDel);
            }
            dBSet.Remove(entityToDel);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dBSet.ToList();
        }

        public IEnumerable<ToDoTask> GetAllTasksById(int id)
        {
            DbSet<ToDoTask> tasks = this.context.ToDoTasks;
            IEnumerable<ToDoTask> query = from task in tasks where task.FolderId == id select task;
            return query;
            
        }

        public TEntity GetById(int id)
        {
          return  dBSet.Find(id);
        }

        public void Update(int id)
        {
            var updateEntity = dBSet.Find(id);
            dBSet.Update(updateEntity);
        }
    }
}
