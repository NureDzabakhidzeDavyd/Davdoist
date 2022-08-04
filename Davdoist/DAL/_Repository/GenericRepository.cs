using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task Add(TEntity entity)
        {
           await dBSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var delEntity = await dBSet.FindAsync(id);
            dBSet.Remove(delEntity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dBSet.ToListAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetAllTasksById(int id)
        {
            DbSet<ToDoTask> tasks = this.context.ToDoTasks;
            return await tasks.Where(x => x.FolderId == id).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
          return await dBSet.FindAsync(id);
        }

        public async Task Update(int id)
        {
            var updateEntity = await dBSet.FindAsync(id);
            dBSet.Update(updateEntity);
        }
    }
}
