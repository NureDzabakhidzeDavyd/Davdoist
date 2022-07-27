using DAL._Repository;
using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public GenericRepository<ToDoTask> TasksRepository { get; }
        public GenericRepository<Folder> FoldersRepository { get; }

        public void Save();
    }
}
