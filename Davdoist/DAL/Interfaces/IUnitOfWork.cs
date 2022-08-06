using DAL._Repository;
using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public GenericRepository<ToDoTask> TasksRepository { get; }

        public GenericRepository<Folder> FoldersRepository { get; }

        public Task Save();
    }
}
