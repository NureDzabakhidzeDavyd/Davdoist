using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class Context : DbContext
    {
        public DbSet<ToDoTask> toDoTasks;
        public DbSet<Folder> folders;

        public Context()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("sdlfjsdlfjlsdfjlksdflj");
        }
    }
}
