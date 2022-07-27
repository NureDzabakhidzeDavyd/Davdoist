using System.Collections.Generic;

namespace BLL.Entities
{
    public class Folder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
    }
}
