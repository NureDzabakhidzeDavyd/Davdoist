using System.Collections.Generic;
using PL.Models;
namespace PL.ViewModels
{
    public class TaskAndFolder
    {
        public IEnumerable<ToDoTask> Tasks { get; set; }
        public IEnumerable<Folder> Folders { get; set; }
    }
}
