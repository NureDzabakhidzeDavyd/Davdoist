using System;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Context;
using DAL._Repository;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TaskAndFolderContext context = new();

        private GenericRepository<ToDoTask> tasksRepository;
        private GenericRepository<Folder> foldersRepository;

        private bool disposed = false;

        public GenericRepository<ToDoTask> TasksRepository
        {
            get
            {
                if (this.tasksRepository == null)
                {
                    this.tasksRepository = new GenericRepository<ToDoTask>(context);
                }
                return tasksRepository;
            }
        }

        public GenericRepository<Folder> FoldersRepository
        {
            get
            {
                if (this.foldersRepository == null)
                {
                    this.foldersRepository = new GenericRepository<Folder>(context);
                }
                return foldersRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
